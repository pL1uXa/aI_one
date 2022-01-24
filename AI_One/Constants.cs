using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AI_One
{
    static class Constants
    {
        public static Random rand = new Random();

        public const int size_first_gen = 100; // Количество клеток в начале
        public static int food_max = 8000; // Количество еды на поле
        public static int update_step = 1; // Обновлять карту каждые N шагов
        public static int mutation = 3; // Шанс мутации (мутирует каждый N)

        public static int map_void = 0; // Обозначение пустоты на карте
        public static int map_eat = 1; // Обозначение еды на карте
        public static int map_block = 2; // Обозначение стены на карте
        public static int map_cell = 3; // Обозначение стены на карте

        public const int energy_max = 100; // Максимальная энергия (и для деления)
        public const int energy_start = 50; // Начальная энергия
        public const int energy_division = 50; // Энергия отнимаемая при делении
        public const int energy_eat = 10; // Энергия за единыцу еды
        public const int energy_consumption = 1; // Потребление энергии за ход
        public const int energy_dead = 0; // При какой энергии клетка умирает

        public const int gen_max = 64; // Высший ген
        public const int gen_count = 64; // Количество ячеек генов
        public const int gen_step = 10; // Количество повторений генов eye, rotation, max
        public const int gen_moving = 8; // Ген: перемещение
        public const int gen_eat = 16; // Ген: еда
        public const int gen_eye = 24; // Ген: посмотреть
        public const int gen_rotation = 32; // Ген: повернуться

        public static void edit_settings(string _update_step, string _food_max)
        {
            update_step = Int32.Parse(_update_step);
            food_max = Int32.Parse(_food_max);
        }
    }
}
