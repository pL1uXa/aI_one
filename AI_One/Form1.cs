using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace AI_One
{
    public partial class Form1 : Form
    {
        private int count_step = 0; // Общее количество шагов timer1
        private List<Cell> cell = new List<Cell>();

        public Form1()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }
        private void Form1_Load(object sender, EventArgs e) // Загрузка
        {
            Map.create_map(); // Создание карты
            Cell.first_generation(Map.map, cell); // Первая партия клеток

            //cell.Add(new Cell(Map.map, new int[] { 63, 34, 37, 55, 12, 40, 61, 34, 0, 20, 6, 1, 36, 43, 36, 18, 62, 17, 56, 32, 21, 30, 62, 39, 4, 53, 8, 28, 18, 29, 19, 57, 20, 4, 30, 0, 54, 14, 46, 55, 27, 4, 25, 52, 7, 22, 40, 54, 58, 19, 19, 13, 37, 54, 31, 41, 30, 9, 57, 36, 49, 56, 43, 4 }, new Point(10, 10)));
            //cell.Add(new Cell(Map.map, new int[] { 21, 34, 4, 57, 21, 24, 46, 34, 36, 26, 6, 58, 50, 36, 58, 34, 28, 0, 28, 55, 21, 30, 60, 39, 38, 53, 3, 26, 3, 45, 41, 48, 20, 38, 23, 0, 13, 51, 36, 32, 2, 4, 22, 55, 7, 22, 40, 2, 62, 5, 19, 52, 42, 20, 50, 8, 19, 37, 37, 50, 49, 43, 18, 3 }, new Point(10, 10)));

            initial_settings(); // Начальные настройки
        }
        private void initial_settings() // Начальные параметры
        {
            textBox_info_cell_gen.Enabled = false;
            textBox_settings_update_step.Text = Constants.update_step.ToString();
            textBox_settings_food_max.Text = Constants.food_max.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e) // Главный таймер
        {
            Cell.update(Map.map, cell); // Обновление клетки
            Cell.division(cell, Map.map); // Проверка и деление клеток
            Draw(); // Отрисовка
        }
        private void Draw() // Отрисовка объектов
        {
            Map.update_map(panel_picture, cell);

            label_info_living_cells.Text = "Живых клеток: " + cell.Count;
            label_info_food.Text = "Еды на поле: " + Map.food;
            label_info_step.Text = "Кол-во шагов пройдено: " + ++count_step;

            if (cell.Count <= 1 && count_step > Constants.energy_max - 5)
            {
                timer1.Enabled = false;
                button_switch.Text = "Выжившие!";
                button_switch.Enabled = false;
                groupBox1.Enabled = false;

                Map.up_step = Constants.update_step - 1;
                Map.update_map(panel_picture, cell);
            }
        }
        private void button_switch_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                button_switch.Text = "Пауза";
                groupBox1.Enabled = false;
            }
            else
            {
                timer1.Enabled = false;
                button_switch.Text = "Продолжить";
                groupBox1.Enabled = true;

                Map.up_step = Constants.update_step - 1;
                Cell.update(Map.map, cell); // Обновление клетки
                Map.update_map(panel_picture, cell);
            }
        }
        private void button_settings_apply_Click(object sender, EventArgs e)
        {
            Constants.edit_settings(textBox_settings_update_step.Text, textBox_settings_food_max.Text);
        }
        private void panel_picture_MouseClick(object sender, MouseEventArgs e)
        {
            int index = Map.get_index_cell(cell, e);
            if (index != -99)
            {
                label_info_cell.Text = cell[index].get_info(1);
                textBox_info_cell_gen.Text = cell[index].get_info(2);
                textBox_info_cell_gen.Enabled = true;
            }
            else
            {
                label_info_cell.Text = "                 Выберите клетку";
                textBox_info_cell_gen.Text = "";
                textBox_info_cell_gen.Enabled = false;
            }
        }
    }
}
