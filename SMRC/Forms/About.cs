using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMRC
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            label1.Text = @"Приложение ''Учет выполнения СМР''

" +
"           версия " +     System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + @". Клиент-сервер
           
           предназначено для интеграции из сметно-аналитического комплекса А0 оперативной информации об объемах выполненных работ,
           формирования справок КС-3,
           аналитика сметных данных.";
        }
    }
}
