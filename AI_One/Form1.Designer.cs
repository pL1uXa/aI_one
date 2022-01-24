namespace AI_One
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_switch = new System.Windows.Forms.Button();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_info = new System.Windows.Forms.TabPage();
            this.groupBox_info_general = new System.Windows.Forms.GroupBox();
            this.label_info_step = new System.Windows.Forms.Label();
            this.label_info_food = new System.Windows.Forms.Label();
            this.label_info_living_cells = new System.Windows.Forms.Label();
            this.groupBox_info_cell = new System.Windows.Forms.GroupBox();
            this.textBox_info_cell_gen = new System.Windows.Forms.TextBox();
            this.label_info_cell = new System.Windows.Forms.Label();
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_settings_food_max = new System.Windows.Forms.Label();
            this.textBox_settings_food_max = new System.Windows.Forms.TextBox();
            this.button_settings_apply = new System.Windows.Forms.Button();
            this.label_settings_update_step = new System.Windows.Forms.Label();
            this.textBox_settings_update_step = new System.Windows.Forms.TextBox();
            this.panel_picture = new AI_One.MyPanel();
            this.tabControl_main.SuspendLayout();
            this.tabPage_info.SuspendLayout();
            this.groupBox_info_general.SuspendLayout();
            this.groupBox_info_cell.SuspendLayout();
            this.tabPage_settings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_switch
            // 
            this.button_switch.Location = new System.Drawing.Point(406, 12);
            this.button_switch.Name = "button_switch";
            this.button_switch.Size = new System.Drawing.Size(228, 23);
            this.button_switch.TabIndex = 2;
            this.button_switch.Text = "Старт";
            this.button_switch.UseVisualStyleBackColor = true;
            this.button_switch.Click += new System.EventHandler(this.button_switch_Click);
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_info);
            this.tabControl_main.Controls.Add(this.tabPage_settings);
            this.tabControl_main.Location = new System.Drawing.Point(406, 41);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(234, 359);
            this.tabControl_main.TabIndex = 4;
            // 
            // tabPage_info
            // 
            this.tabPage_info.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_info.Controls.Add(this.groupBox_info_general);
            this.tabPage_info.Controls.Add(this.groupBox_info_cell);
            this.tabPage_info.Location = new System.Drawing.Point(4, 22);
            this.tabPage_info.Name = "tabPage_info";
            this.tabPage_info.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_info.Size = new System.Drawing.Size(226, 333);
            this.tabPage_info.TabIndex = 0;
            this.tabPage_info.Text = "Информация";
            // 
            // groupBox_info_general
            // 
            this.groupBox_info_general.Controls.Add(this.label_info_step);
            this.groupBox_info_general.Controls.Add(this.label_info_food);
            this.groupBox_info_general.Controls.Add(this.label_info_living_cells);
            this.groupBox_info_general.Location = new System.Drawing.Point(6, 6);
            this.groupBox_info_general.Name = "groupBox_info_general";
            this.groupBox_info_general.Size = new System.Drawing.Size(214, 78);
            this.groupBox_info_general.TabIndex = 7;
            this.groupBox_info_general.TabStop = false;
            this.groupBox_info_general.Text = "Общая информация";
            // 
            // label_info_step
            // 
            this.label_info_step.AutoSize = true;
            this.label_info_step.Location = new System.Drawing.Point(6, 58);
            this.label_info_step.Name = "label_info_step";
            this.label_info_step.Size = new System.Drawing.Size(132, 13);
            this.label_info_step.TabIndex = 2;
            this.label_info_step.Text = "Кол-во шагов пройдено: ";
            // 
            // label_info_food
            // 
            this.label_info_food.AutoSize = true;
            this.label_info_food.Location = new System.Drawing.Point(6, 41);
            this.label_info_food.Name = "label_info_food";
            this.label_info_food.Size = new System.Drawing.Size(73, 13);
            this.label_info_food.TabIndex = 1;
            this.label_info_food.Text = "Еды на поле:";
            // 
            // label_info_living_cells
            // 
            this.label_info_living_cells.AutoSize = true;
            this.label_info_living_cells.Location = new System.Drawing.Point(6, 24);
            this.label_info_living_cells.Name = "label_info_living_cells";
            this.label_info_living_cells.Size = new System.Drawing.Size(87, 13);
            this.label_info_living_cells.TabIndex = 0;
            this.label_info_living_cells.Text = "Живых клеток: ";
            // 
            // groupBox_info_cell
            // 
            this.groupBox_info_cell.Controls.Add(this.textBox_info_cell_gen);
            this.groupBox_info_cell.Controls.Add(this.label_info_cell);
            this.groupBox_info_cell.Location = new System.Drawing.Point(6, 90);
            this.groupBox_info_cell.Name = "groupBox_info_cell";
            this.groupBox_info_cell.Size = new System.Drawing.Size(214, 235);
            this.groupBox_info_cell.TabIndex = 6;
            this.groupBox_info_cell.TabStop = false;
            this.groupBox_info_cell.Text = "Информация по клетке";
            // 
            // textBox_info_cell_gen
            // 
            this.textBox_info_cell_gen.Location = new System.Drawing.Point(6, 209);
            this.textBox_info_cell_gen.Name = "textBox_info_cell_gen";
            this.textBox_info_cell_gen.Size = new System.Drawing.Size(202, 20);
            this.textBox_info_cell_gen.TabIndex = 6;
            // 
            // label_info_cell
            // 
            this.label_info_cell.AutoSize = true;
            this.label_info_cell.Location = new System.Drawing.Point(6, 27);
            this.label_info_cell.Name = "label_info_cell";
            this.label_info_cell.Size = new System.Drawing.Size(145, 13);
            this.label_info_cell.TabIndex = 5;
            this.label_info_cell.Text = "                 Выберите клетку";
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_settings.Controls.Add(this.groupBox1);
            this.tabPage_settings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(226, 333);
            this.tabPage_settings.TabIndex = 1;
            this.tabPage_settings.Text = "Настройки";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_settings_food_max);
            this.groupBox1.Controls.Add(this.textBox_settings_food_max);
            this.groupBox1.Controls.Add(this.button_settings_apply);
            this.groupBox1.Controls.Add(this.label_settings_update_step);
            this.groupBox1.Controls.Add(this.textBox_settings_update_step);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 319);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label_settings_food_max
            // 
            this.label_settings_food_max.AutoSize = true;
            this.label_settings_food_max.Location = new System.Drawing.Point(6, 61);
            this.label_settings_food_max.Name = "label_settings_food_max";
            this.label_settings_food_max.Size = new System.Drawing.Size(188, 13);
            this.label_settings_food_max.TabIndex = 9;
            this.label_settings_food_max.Text = "Максимальное кол-во еды на поле:";
            // 
            // textBox_settings_food_max
            // 
            this.textBox_settings_food_max.Location = new System.Drawing.Point(6, 77);
            this.textBox_settings_food_max.Name = "textBox_settings_food_max";
            this.textBox_settings_food_max.Size = new System.Drawing.Size(202, 20);
            this.textBox_settings_food_max.TabIndex = 8;
            // 
            // button_settings_apply
            // 
            this.button_settings_apply.Location = new System.Drawing.Point(6, 290);
            this.button_settings_apply.Name = "button_settings_apply";
            this.button_settings_apply.Size = new System.Drawing.Size(202, 23);
            this.button_settings_apply.TabIndex = 7;
            this.button_settings_apply.Text = "Применить";
            this.button_settings_apply.UseVisualStyleBackColor = true;
            this.button_settings_apply.Click += new System.EventHandler(this.button_settings_apply_Click);
            // 
            // label_settings_update_step
            // 
            this.label_settings_update_step.AutoSize = true;
            this.label_settings_update_step.Location = new System.Drawing.Point(6, 16);
            this.label_settings_update_step.Name = "label_settings_update_step";
            this.label_settings_update_step.Size = new System.Drawing.Size(197, 13);
            this.label_settings_update_step.TabIndex = 6;
            this.label_settings_update_step.Text = "Частота прорисовки карты (в шагах):";
            // 
            // textBox_settings_update_step
            // 
            this.textBox_settings_update_step.Location = new System.Drawing.Point(6, 32);
            this.textBox_settings_update_step.Name = "textBox_settings_update_step";
            this.textBox_settings_update_step.Size = new System.Drawing.Size(202, 20);
            this.textBox_settings_update_step.TabIndex = 5;
            // 
            // panel_picture
            // 
            this.panel_picture.BackColor = System.Drawing.SystemColors.Window;
            this.panel_picture.Location = new System.Drawing.Point(0, 0);
            this.panel_picture.Name = "panel_picture";
            this.panel_picture.Size = new System.Drawing.Size(400, 400);
            this.panel_picture.TabIndex = 1;
            this.panel_picture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_picture_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 400);
            this.Controls.Add(this.panel_picture);
            this.Controls.Add(this.tabControl_main);
            this.Controls.Add(this.button_switch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_info.ResumeLayout(false);
            this.groupBox_info_general.ResumeLayout(false);
            this.groupBox_info_general.PerformLayout();
            this.groupBox_info_cell.ResumeLayout(false);
            this.groupBox_info_cell.PerformLayout();
            this.tabPage_settings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_switch;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_info;
        private System.Windows.Forms.TabPage tabPage_settings;
        private System.Windows.Forms.GroupBox groupBox_info_cell;
        private System.Windows.Forms.Label label_info_cell;
        private System.Windows.Forms.GroupBox groupBox_info_general;
        private System.Windows.Forms.Label label_info_living_cells;
        private System.Windows.Forms.Label label_info_food;
        private System.Windows.Forms.Label label_info_step;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_settings_food_max;
        private System.Windows.Forms.TextBox textBox_settings_food_max;
        private System.Windows.Forms.Button button_settings_apply;
        private System.Windows.Forms.Label label_settings_update_step;
        public System.Windows.Forms.TextBox textBox_settings_update_step;
        private System.Windows.Forms.TextBox textBox_info_cell_gen;
        public MyPanel panel_picture;
    }
}

