using System;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;
using System.Data;
using CrudWForms.Classes;

public class AcessoFB
{
    private static readonly AcessoFB instanciaFireBird = new AcessoFB();
    private AcessoFB() { }

    public static AcessoFB getInstancia()
    {
        return instanciaFireBird;
    }

    public FbConnection getConexao()
    {
        string conn = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ToString();
        return new FbConnection(conn);
    }

    public static DataTable fb_GetDados()
    {
        using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
        {
            try
            {
                conexaoFireBird.Open();
                string mSQL = "Select * from " + '\u0022' + "clientes" + '\u0022';
                FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                FbDataAdapter da = new FbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (FbException fbex)
            {
                throw fbex;
            }
            finally
            {
                conexaoFireBird.Close();
            }
        }
    }

    public static void fb_InserirDados(Cliente cliente)
    {
        using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
        {
            try
            {
                conexaoFireBird.Open();
                string mSQL = "INSERT into " + '\u0022' + "clientes" + '\u0022' + " Values (" + cliente.ID + ",'" + cliente.Nome + "')";

                FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                cmd.ExecuteNonQuery();
            }
            catch (FbException fbex)
            {
                throw fbex;
            }
            finally
            {
                conexaoFireBird.Close();
            }
        }
    }
    public static void fb_ExcluirDados(int id)
    {
        using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
        {
            try
            {
                conexaoFireBird.Open();
                string mSQL = "DELETE from " + '\u0022' + "clientes" + '\u0022' + " Where id= " + id;
                FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                cmd.ExecuteNonQuery();
            }
            catch (FbException fbex)
            {
                throw fbex;
            }
            finally
            {
                conexaoFireBird.Close();
            }
        }
    }

    public static Cliente fb_ProcuraDados(int id)
    {
        using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
        {
            try
            {
                conexaoFireBird.Open();
                string mSQL = "Select * from " + '\u0022' + "clientes" + '\u0022' + " Where id = " + id;
                FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                FbDataReader dr = cmd.ExecuteReader();
                Cliente cliente = new Cliente();
                while (dr.Read())
                {
                    cliente.ID = Convert.ToInt32(dr[0]);
                    cliente.Nome = dr[1].ToString();
                }
                return cliente;
            }
            catch (FbException fbex)
            {
                throw fbex;
            }
            finally
            {
                conexaoFireBird.Close();
            }
        }
    }
    public static void fb_AlterarDados(Cliente cliente)
    {
        using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
        {
            try
            {
                conexaoFireBird.Open();
                string mSQL = "Update " + '\u0022' + "clientes" + '\u0022' +
                    " set " + '\u0022' + "nome" + '\u0022' + " = '" + cliente.Nome + "'" +
                    " Where " + '\u0022' + "id" + '\u0022' + " = " + cliente.ID;


                FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                cmd.ExecuteNonQuery();
            }
            catch (FbException fbex)
            {
                throw fbex;
            }
            finally
            {
                conexaoFireBird.Close();
            }
        }
    }
}
