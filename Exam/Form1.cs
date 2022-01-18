using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Exam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XDocument xdoc = new XDocument();//создаем xml файл
            var surname = new XElement("surname");//создаем элемент с фамилиией, это главный тег, под ним юудет хранится имя отчество и тд
            var surnameAtr = new XAttribute("surname", textBox1.Text);//далее проходимся по текст боксам и берем оттуда данные,
            var name = new XElement("name", textBox2.Text);           //паралельно создавая елементы имени, отчества и тд
            var patronymic = new XElement("patronymic", textBox3.Text);
            var age = new XElement("age", textBox4.Text);
            var email = new XElement("email", textBox5.Text);
            surname.Add(surnameAtr);//теперь все эти элементы добавляем в корневой тег
            surname.Add(name);
            surname.Add(patronymic);
            surname.Add(age);
            surname.Add(email);
            xdoc.Add(surname);//ну и сам коревой тег в документ
            xdoc.Save("human.xml");//и сохраняем документ
        }
    }
}
