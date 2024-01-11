#define MySQL

#if MySQL
using DbConnection = MySql.Data.MySqlClient.MySqlConnection;
using DbConnectionStringBuilder = MySql.Data.MySqlClient.MySqlConnectionStringBuilder;
using DbCommand = MySql.Data.MySqlClient.MySqlCommand;
#endif

using System.Data.Common;

namespace GratisDL;
public static class DL
{

# if MySQL 
#endif



    static DbConnection conn = new(new DbConnectionStringBuilder()
    {
#if MySQL
        Server = "localhost", //gerçek durumda server ip'si
        UserID = "root", //veri tabanı kullanıcı adı
        Password = "Ankara06",
        Database = "gratis",
        //SslMode=MySqlConnector.MySqlSslMode.None,
        //AllowPublicKeyRetrieval = true,
#endif
    }.ConnectionString);

    public static int MusteriEkle(String musteri_id, string musteri_ad, string musteri_soyad, string telno, string mail, string adres,
        out string error)
    {
        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "MusteriEkle";
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            com.Parameters.AddWithValue("in_musteri_id", musteri_id);// tırnak içindekiler store prosedürün paremetreleri
            com.Parameters.AddWithValue("in_musteri_ad", musteri_ad);
            com.Parameters.AddWithValue("in_musteri_soyad", musteri_soyad);
            com.Parameters.AddWithValue("in_telno", telno);
            com.Parameters.AddWithValue("in_mail", mail);
            com.Parameters.AddWithValue("in_adres", adres);
            error = "";
            return com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            error = ex.Message;
            return -1;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }

    public static int MusteriEkle(string ıD, string ad, string soyad, string telefon, string mail, out string error)
    {
        throw new NotImplementedException();
    }

    public static int MusteriGuncelle(String musteri_id, string musteri_ad, string musteri_soyad, string telno, string mail, string adres,
        out string error)
    {
        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "MusteriGuncelle"; // store prosedürün adı
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            com.Parameters.AddWithValue("in_musteri_id", musteri_id);// tırnak içindekiler store prosedürün paremetreleri
            com.Parameters.AddWithValue("in_musteri_ad", musteri_ad);
            com.Parameters.AddWithValue("in_musteri_soyad", musteri_soyad);
            com.Parameters.AddWithValue("in_telno", telno);
            com.Parameters.AddWithValue("in_mail", mail);
            com.Parameters.AddWithValue("in_adres", adres);
            error = "";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);


            error = ex.Message;
            return -1;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }

    public static int MusteriSil(String musteri_id, out string error)
    {
        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "MusteriSil";
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure,

            };
            com.Parameters.AddWithValue("in_musteri_id", musteri_id);

            error = "";
            return com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            error = ex.Message;
            return -1;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }

   

}
