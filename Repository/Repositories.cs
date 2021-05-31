using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProjetoPainel.Mapper;
using ProjetoPainel.Models;
using ProjetoPainel.Repository.Interface;
using RPA._000.RetornaCarteirasAPI.Models;
using RPA._000.RetornaCarteirasAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPainel.Repository
{
    public class Repositories : IRepository
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICarteiraPessoaRepository _carteiraPessoaRepository;
        private readonly IMapper _CarteiraPessoaMapper;
        private readonly IMapper _PessoaMapper;
        public Repositories(
            IPessoaRepository pessoaRepository,
            ICarteiraPessoaRepository carteiraPessoaRepository)
        {
            this._pessoaRepository = pessoaRepository;
            this._carteiraPessoaRepository = carteiraPessoaRepository;
            var configCarteiraPessoa = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarteiraPessoaMapper>();
            });

            var configPessoa = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PessoaMapper>();
            });

            _CarteiraPessoaMapper = configCarteiraPessoa.CreateMapper();
            _PessoaMapper = configPessoa.CreateMapper();
        }
        
        static NpgsqlConnection connection = new NpgsqlConnection("Server=10.20.11.141;Port=5432;User ID=plcp001-user;Password=pieso3suW9huK3Leidia;Database=plcp001;CommandTimeout=0;");
        static NpgsqlTransaction transaction;
        public bool AssociarPessoaCarteira(InCarteiraPessoa inCarteiraPessoa)
        {
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                var verificaCarteira = VerificaCarteira(inCarteiraPessoa.cod_carteira);
                var verificaAssociacoes = VerificaAssociacao(inCarteiraPessoa.cod_carteira);

                if (verificaCarteira && verificaAssociacoes)
                    InsereCarteiraPessoa(inCarteiraPessoa);
                else if (verificaCarteira && !verificaAssociacoes)
                    AtualizaCarteiraPessoa(inCarteiraPessoa);
                else
                    return false;

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public void InserePessoa(string nomePessoa, int cargo)
        {
            try
            {
                _pessoaRepository.inserirPessoa(new InPessoa { nomePessoa = nomePessoa, cargo = cargo });
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao tentar salvar uma nova pessoa");
            }          
        }

        private void InsereCarteiraPessoa(InCarteiraPessoa inCarteiraPessoa)
        {
            var super = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_super));
            var executivo = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_executivo));
            var coordenador = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_coordenador));
            var bp = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_bp));
            var lidertecnico = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_lidertecnico));
            var programador = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_programador));

            _carteiraPessoaRepository.InsereCarteiraPessoa(new Rpa_carteirapessoa
            {
                Super = super,
                Executivo = executivo,
                Cod_carteira = inCarteiraPessoa.cod_carteira,
                Coordenador = coordenador,
                BP = bp,
                LiderTecnico = lidertecnico,
                Programador = programador
            });
        }

        private PessoaModel buscaPessoa(int id)
        {
            return _PessoaMapper.Map<PessoaModel>(_pessoaRepository.buscaPessoa(id));
        }

        private void AtualizaCarteiraPessoa(InCarteiraPessoa inCarteiraPessoa)
        {
            var super = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_super));
            var executivo = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_executivo));
            var coordenador = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_coordenador));
            var bp = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_bp));
            var lidertecnico = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_lidertecnico));
            var programador = _PessoaMapper.Map<Rpa_pessoa>(buscaPessoa(inCarteiraPessoa.id_programador));

            var carteirapessoa = _carteiraPessoaRepository.GetCarteirapessoa(inCarteiraPessoa.cod_carteira);

            carteirapessoa.Super = super;
            carteirapessoa.Executivo = executivo;
            carteirapessoa.Coordenador = coordenador;
            carteirapessoa.BP = bp;
            carteirapessoa.LiderTecnico = lidertecnico;
            carteirapessoa.Programador = programador;

            _carteiraPessoaRepository.AtualizaCarteiraPessoa(carteirapessoa);
        }

        private bool VerificaCarteira(int codCarteira)
        {
            var sql = $"select * from view_carteira vc where id_gecliente_int = {codCarteira}";

            var command = new NpgsqlCommand(sql, connection, transaction);
            var reader = command.ExecuteScalar();
            return !reader.Equals(null);
        }

        private bool VerificaAssociacao(int codCarteira)
        {
            var response = _carteiraPessoaRepository.GetCarteirapessoa(codCarteira);
            return response != null;
        }

        public List<PessoaModel> GetPessoas()
        {
            var result = new List<PessoaModel>();
            try
            {
                var response = _pessoaRepository.getPessoas();
                return _PessoaMapper.Map<List<PessoaModel>>(response);
            }
            catch
            {
                return result;
            }
        }

        public CarteiraModel GetCarteiraPorID(int codigoCarteira)
        {
            var result = new CarteiraModel();
            try
            {
                var response = _carteiraPessoaRepository.getCarteiraPorId(codigoCarteira);
                result = _CarteiraPessoaMapper.Map<CarteiraModel>(response);
                return result;
            }
            catch(Exception ex)
            {
                result.erro = ex.Message != null;
                return result;
            }
            
                /*string sql = @"select vc.cod,
                                      vc.id_gecliente_int,
                                      vc.carteira,
                                      vc.tab_filha,
                                      vc.ip,
                                      vc.banco,
                                      vc.usuario,
                                      vc.senha,
                                      sp.id idsuper,
                                      sp.nome super,
                                      ex.id idexecutivo,
                                      ex.nome executivo,
                                      co.id idcoordenador,
                                      co.nome coordenador,
                                      bp.id idbp,
                                      bp.nome bp,
                                      lt.id idlidertecnico,
                                      lt.nome lidertecnico,
                                      pr.id idprogramador,
                                      pr.nome programador
                                 from view_carteira vc
                                 left join rpa_carteirapessoa cp
                                   on vc.id_gecliente_int = cp.cod_carteira
                                 left join rpa_pessoa sp
                                   on sp.Id = cp.id_super
                                 left join rpa_pessoa ex
                                   on ex.Id = cp.id_executivo
                                 left join rpa_pessoa co
                                   on co.Id = cp.id_coordenador
                                 left join rpa_pessoa bp
                                   on bp.Id = cp.id_bp
                                 left join rpa_pessoa lt
                                   on lt.Id = cp.id_lidertecnico
                                 left join rpa_pessoa pr
                                   on pr.Id = cp.id_programador
                                where id_gecliente_int = " + codigoCarteira;

                DataAccess.ExecuteSQLStrategy(connection =>
                {
                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    dr.Read();

                    response.cod = Convert.ToString(dr["cod"]);
                    response.banco = Convert.ToString(dr["banco"]);
                    response.carteira = Convert.ToString(dr["carteira"]);
                    response.id_gecliente_int = Convert.ToInt32(dr["id_gecliente_int"]);
                    response.senha = Convert.ToString(dr["senha"]);
                    response.ip = Convert.ToString(dr["ip"]);
                    response.tab_filha = Convert.ToString(dr["tab_filha"]);
                    response.usuario = Convert.ToString(dr["usuario"]);

                    response.super = Convert.ToString(dr["super"]);
                    response.executivo = Convert.ToString(dr["executivo"]);
                    response.coordenador = Convert.ToString(dr["coordenador"]);
                    response.bp = Convert.ToString(dr["bp"]);
                    response.lidertecnico = Convert.ToString(dr["lidertecnico"]);
                    response.programador = Convert.ToString(dr["programador"]);

                    response.idsuper = dr.IsDBNull(8) ? 0 : Convert.ToInt32(dr["idsuper"]);
                    response.idexecutivo = dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr["idexecutivo"]);
                    response.idcoordenador = dr.IsDBNull(12) ? 0 : Convert.ToInt32(dr["idcoordenador"]);
                    response.idbp = dr.IsDBNull(14) ? 0 : Convert.ToInt32(dr["idbp"]);
                    response.idlidertecnico = dr.IsDBNull(16) ? 0 : Convert.ToInt32(dr["idlidertecnico"]);
                    response.idprogramador = dr.IsDBNull(18) ? 0 : Convert.ToInt32(dr["idprogramador"]);

                    response.erro = false;
                });
            }
            catch (Exception ex)
            {
                response.erro = true;
                Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss" + " - " + "Erro-" + ex.Message));
            }
            return response;*/
        }
    }
}
