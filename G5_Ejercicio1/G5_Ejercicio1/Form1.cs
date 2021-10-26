using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G5_Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BorrarMensaje()
        {
            //Borra los mensajes para que no se muestren y pueda limpiar
            errorProvider1.SetError(txtnombre, "");
            errorProvider1.SetError(txtapellido, "");
            errorProvider1.SetError(dtpFechaNacimiento, "");
        }

        private bool validarcampos()
        {
            //Variable que verifica si algo ha sido validado
            bool validado = true;

            if (txtnombre.Text == "") //Verifica que no quede vacio el campo
            {
                validado = false; //Si está vacio, validado es falso
                errorProvider1.SetError(txtnombre, "Ingresar nombre"); //Por lo tanto manda a llamar al ErrorProvider

                //En los parametros de setError se identifica a quien estoy validando y el mensaje que deseo mandar
            }

            //Verifico la casilla de apellido
            if (txtapellido.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtapellido, "Ingrese apellido");
            }
            return validado;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //limpia cualquier mensaje de error de alguna corrida previa
            BorrarMensaje();

            //Verificamos la fecha de nacimiento que nos den 
            //DateTimePicker se llama dtpFechaNaciemiento
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;

            if (fechaNacimiento.Date > DateTime.Now.Date)
            {
                errorProvider1.SetError(dtpFechaNacimiento, "Esta fecha es del futuro");

            }
            else
            {
                //  Llamamos al metodo para validar campos, el de nombre y apellido
                if (validarcampos())
                {
                    MessageBox.Show("Los datos se ingresaron correctamente");
                }



                //Verificamos la fecha del sistema (Solo calculamos los años)
                int años = System.DateTime.Now.Year - fechaNacimiento.Year;

                //Verificamos aparte del año si ya pasamos la fecha de nacimiento de este año o nos faltan días
                if (System.DateTime.Now.Subtract(fechaNacimiento.AddYears(años)).TotalDays < 0)
                {
                    //Si nos faltan días para cumplir años, al calculo le resta uno
                    txtedad.Text = Convert.ToString(años - 1);
                }
                else
                {
                    //Si ya pasó nuestra fecha de naciemiento manda el valor correspondiente
                    txtedad.Text = Convert.ToString(años);
                }
            }
            
        }

        private void dtpFechaNacimiento_Leave(object sender, EventArgs e)
        {
        }
    }
}
