using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CRUD_Cadastro_de_Funcionarios
{
    public partial class Funcionarios : Form
    {
        public Funcionarios()
        {
            InitializeComponent();

            txtBuscar.Enabled = true;
            txtBairro.Enabled = false;
            txtCelular.Enabled = false;
            txtCEP.Enabled = false;
            txtEstado.Enabled = false;
            txtCidade.Enabled = false;
            txtCPF.Enabled = false;
            txtEmail.Enabled = false;
            txtNome.Enabled = false;
            txtNumero.Enabled = false;
            txtRG.Enabled = false;
            txtLogadouro.Enabled = false;
            txtTelefone.Enabled = false;

        }

        SqlConnection sqlConnect = null;
        private string strConnect = @"Server=DESKTOP-VPO5MAN\SQLEXPRESS;Database=EmpresaFicticia;User Id=sa;Password=@senhafoda2021;";
        private string strSql = string.Empty;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtBairro.Clear();
            txtCelular.Clear();
            txtCEP.Clear();
            txtEstado.Clear();
            txtCidade.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtNome.Clear();
            txtNumero.Clear();
            txtRG.Clear();
            txtLogadouro.Clear();
            txtTelefone.Clear();

            txtBuscar.Enabled = false;
            txtBairro.Enabled = true;
            txtCelular.Enabled = true;
            txtCEP.Enabled = true;
            txtEstado.Enabled = true;
            txtCidade.Enabled = true;
            txtCPF.Enabled = true;
            txtEmail.Enabled = true;
            txtNome.Enabled = true;
            txtNumero.Enabled = true;
            txtRG.Enabled = true;
            txtLogadouro.Enabled = true;
            txtTelefone.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            strSql = "INSERT INTO CadFuncionarios (Nome,Telefone,Celular,Email,RG,CPF,Estado,Cidade,Logadouro,Numero,Bairro,CEP) values(@Nome,@Telefone,@Celular,@Email,@RG,@CPF,@Estado,@Cidade,@Logadouro,@Numero,@Bairro,@CEP)";

            sqlConnect = new SqlConnection(strConnect);

            SqlCommand comando = new SqlCommand(strSql, sqlConnect);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = txtTelefone.Text;
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = txtCelular.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
            comando.Parameters.Add("@RG", SqlDbType.VarChar).Value = txtRG.Text;
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = txtCPF.Text;
            comando.Parameters.Add("@Estado", SqlDbType.VarChar).Value = txtEstado.Text;
            comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("@Logadouro", SqlDbType.VarChar).Value = txtLogadouro.Text;
            comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txtNumero.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = txtCEP.Text;

            try
            {
                sqlConnect.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("CADASTRO EFETUADO COM SUCESSO!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnect.Close();
            }


            txtBairro.Clear();
            txtCelular.Clear();
            txtCEP.Clear();
            txtEstado.Clear();
            txtCidade.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtNome.Clear();
            txtNumero.Clear();
            txtRG.Clear();
            txtLogadouro.Clear();
            txtTelefone.Clear();

            txtBuscar.Enabled = true;
            txtBairro.Enabled = false;
            txtCelular.Enabled = false;
            txtCEP.Enabled = false;
            txtEstado.Enabled = false;
            txtCidade.Enabled = false;
            txtCPF.Enabled = false;
            txtEmail.Enabled = false;
            txtNome.Enabled = false;
            txtNumero.Enabled = false;
            txtRG.Enabled = false;
            txtLogadouro.Enabled = false;
            txtTelefone.Enabled = false;


        }



        private void bntBuscar_Click(object sender, EventArgs e)
        {
            strSql = "SELECT *FROM CadFuncionarios WHERE Nome = @Buscar;";

            sqlConnect = new SqlConnection(strConnect);

            SqlCommand comando = new SqlCommand(strSql, sqlConnect);

            comando.Parameters.Add("@Buscar", SqlDbType.VarChar).Value = txtBuscar.Text;

            try
            {
                if (txtBuscar.Text == string.Empty)
                {
                    MessageBox.Show("VOCÊ PRECISA DIGITAR UM NOME!");
                }
                else
                {
                    sqlConnect.Open();
                    SqlDataReader dr = comando.ExecuteReader();

                    if (dr.HasRows == false)
                    {
                        throw new Exception("ESTE NOME NÃO ESTÁ  CADASTRADO!");
                    }
                    else
                    {
                        dr.Read();

                        txtNome.Text = Convert.ToString(dr["Nome"]);
                        txtTelefone.Text = Convert.ToString(dr["Telefone"]);
                        txtCelular.Text = Convert.ToString(dr["Celular"]);
                        txtEmail.Text = Convert.ToString(dr["Email"]);
                        txtRG.Text = Convert.ToString(dr["RG"]);
                        txtCPF.Text = Convert.ToString(dr["CPF"]);
                        txtEstado.Text = Convert.ToString(dr["Estado"]);
                        txtCidade.Text = Convert.ToString(dr["Cidade"]);
                        txtLogadouro.Text = Convert.ToString(dr["Logadouro"]);
                        txtNumero.Text = Convert.ToString(dr["Numero"]);
                        txtBairro.Text = Convert.ToString(dr["Bairro"]);
                        txtCEP.Text = Convert.ToString(dr["CEP"]);

                        txtBuscar.Enabled = true;
                        txtBairro.Enabled = true;
                        txtCelular.Enabled = true;
                        txtCEP.Enabled = true;
                        txtEstado.Enabled = true;
                        txtCidade.Enabled = true;
                        txtCPF.Enabled = true;
                        txtEmail.Enabled = true;
                        txtNome.Enabled = true;
                        txtNumero.Enabled = true;
                        txtRG.Enabled = true;
                        txtLogadouro.Enabled = true;
                        txtTelefone.Enabled = true;

                    }
            
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnect.Close();
            }
            

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            txtBairro.Clear();
            txtCelular.Clear();
            txtCEP.Clear();
            txtEstado.Clear();
            txtCidade.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtNome.Clear();
            txtNumero.Clear();
            txtRG.Clear();
            txtLogadouro.Clear();
            txtTelefone.Clear();

            txtBuscar.Enabled = false;
            txtBairro.Enabled = true;
            txtCelular.Enabled = true;
            txtCEP.Enabled = true;
            txtEstado.Enabled = true;
            txtCidade.Enabled = true;
            txtCPF.Enabled = true;
            txtEmail.Enabled = true;
            txtNome.Enabled = true;
            txtNumero.Enabled = true;
            txtRG.Enabled = true;
            txtLogadouro.Enabled = true;
            txtTelefone.Enabled = true;


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            strSql = "UPDATE CadFuncionarios SET Nome=@Nome,Telefone=@Telefone,Celular=@Celular,Email=@Email,RG=@RG,CPF=@CPF,Estado=@Estado,Cidade=@Cidade,Logadouro=@Logadouro,Numero=@Numero,Bairro=@Bairro,CEP=@CEP WHERE Nome=@Buscar;";

            sqlConnect = new SqlConnection(strConnect);

            SqlCommand comando = new SqlCommand(strSql, sqlConnect);

            comando.Parameters.Add("@Buscar", SqlDbType.VarChar).Value = txtBuscar.Text;
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = txtTelefone.Text;
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = txtCelular.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
            comando.Parameters.Add("@RG", SqlDbType.VarChar).Value = txtRG.Text;
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = txtCPF.Text;
            comando.Parameters.Add("@Estado", SqlDbType.VarChar).Value = txtEstado.Text;
            comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("@Logadouro", SqlDbType.VarChar).Value = txtLogadouro.Text;
            comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txtNumero.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = txtCEP.Text;

            try
            {
                sqlConnect.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("CADASTRO ALTERADO COM SUCESSO!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnect.Close();
            }


            txtBairro.Clear();
            txtCelular.Clear();
            txtCEP.Clear();
            txtEstado.Clear();
            txtCidade.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtNome.Clear();
            txtNumero.Clear();
            txtRG.Clear();
            txtLogadouro.Clear();
            txtTelefone.Clear();

            txtBuscar.Enabled = true;
            txtBairro.Enabled = false;
            txtCelular.Enabled = false;
            txtCEP.Enabled = false;
            txtEstado.Enabled = false;
            txtCidade.Enabled = false;
            txtCPF.Enabled = false;
            txtEmail.Enabled = false;
            txtNome.Enabled = false;
            txtNumero.Enabled = false;
            txtRG.Enabled = false;
            txtLogadouro.Enabled = false;
            txtTelefone.Enabled = false;

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            strSql = "DELETE FROM CadFuncionarios  WHERE Nome = @Nome ";

            sqlConnect = new SqlConnection(strConnect);

            SqlCommand comando = new SqlCommand(strSql, sqlConnect);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;

            try
            {
                if (txtNome.Text == string.Empty)
                {
                    MessageBox.Show("VOCÊ PRECISA DIGITAR UM NOME!");
                }
                else
                {
                    sqlConnect.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("CADASTRO EXCLUÍDO COM SUCESSO!!!");


                    txtBairro.Clear();
                    txtCelular.Clear();
                    txtCEP.Clear();
                    txtEstado.Clear();
                    txtCidade.Clear();
                    txtCPF.Clear();
                    txtEmail.Clear();
                    txtNome.Clear();
                    txtNumero.Clear();
                    txtRG.Clear();
                    txtLogadouro.Clear();
                    txtTelefone.Clear();

                    txtBuscar.Enabled = true;
                    txtBairro.Enabled = false;
                    txtCelular.Enabled = false;
                    txtCEP.Enabled = false;
                    txtEstado.Enabled = false;
                    txtCidade.Enabled = false;
                    txtCPF.Enabled = false;
                    txtEmail.Enabled = false;
                    txtNome.Enabled = false;
                    txtNumero.Enabled = false;
                    txtRG.Enabled = false;
                    txtLogadouro.Enabled = false;
                    txtTelefone.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnect.Close();
            }
            txtBuscar.Clear();
        }
    }
}
