namespace Knapsack_problems
{
    partial class show_db
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tasktypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backpackweightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberofitemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datetimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solvingthebackpackproblemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.knapsack_problems_dbDataSet = new Knapsack_problems.knapsack_problems_dbDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.solving_the_backpack_problemTableAdapter = new Knapsack_problems.knapsack_problems_dbDataSetTableAdapters.Solving_the_backpack_problemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solvingthebackpackproblemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapsack_problems_dbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.tasktypeDataGridViewTextBoxColumn,
            this.backpackweightDataGridViewTextBoxColumn,
            this.numberofitemsDataGridViewTextBoxColumn,
            this.answerDataGridViewTextBoxColumn,
            this.itemsDataGridViewTextBoxColumn,
            this.datetimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.solvingthebackpackproblemBindingSource;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView1.Location = new System.Drawing.Point(-2, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(813, 387);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 47;
            // 
            // tasktypeDataGridViewTextBoxColumn
            // 
            this.tasktypeDataGridViewTextBoxColumn.DataPropertyName = "Task_type";
            this.tasktypeDataGridViewTextBoxColumn.HeaderText = "Task_type";
            this.tasktypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tasktypeDataGridViewTextBoxColumn.Name = "tasktypeDataGridViewTextBoxColumn";
            this.tasktypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // backpackweightDataGridViewTextBoxColumn
            // 
            this.backpackweightDataGridViewTextBoxColumn.DataPropertyName = "Backpack_weight";
            this.backpackweightDataGridViewTextBoxColumn.HeaderText = "Backpack_weight";
            this.backpackweightDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.backpackweightDataGridViewTextBoxColumn.Name = "backpackweightDataGridViewTextBoxColumn";
            this.backpackweightDataGridViewTextBoxColumn.ReadOnly = true;
            this.backpackweightDataGridViewTextBoxColumn.Width = 142;
            // 
            // numberofitemsDataGridViewTextBoxColumn
            // 
            this.numberofitemsDataGridViewTextBoxColumn.DataPropertyName = "Number_of_items";
            this.numberofitemsDataGridViewTextBoxColumn.HeaderText = "Number_of_items";
            this.numberofitemsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numberofitemsDataGridViewTextBoxColumn.Name = "numberofitemsDataGridViewTextBoxColumn";
            this.numberofitemsDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberofitemsDataGridViewTextBoxColumn.Width = 141;
            // 
            // answerDataGridViewTextBoxColumn
            // 
            this.answerDataGridViewTextBoxColumn.DataPropertyName = "Answer";
            this.answerDataGridViewTextBoxColumn.HeaderText = "Answer";
            this.answerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.answerDataGridViewTextBoxColumn.Name = "answerDataGridViewTextBoxColumn";
            this.answerDataGridViewTextBoxColumn.ReadOnly = true;
            this.answerDataGridViewTextBoxColumn.Width = 80;
            // 
            // itemsDataGridViewTextBoxColumn
            // 
            this.itemsDataGridViewTextBoxColumn.DataPropertyName = "Items";
            this.itemsDataGridViewTextBoxColumn.HeaderText = "Items";
            this.itemsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.itemsDataGridViewTextBoxColumn.Name = "itemsDataGridViewTextBoxColumn";
            this.itemsDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemsDataGridViewTextBoxColumn.Width = 68;
            // 
            // datetimeDataGridViewTextBoxColumn
            // 
            this.datetimeDataGridViewTextBoxColumn.DataPropertyName = "Date_time";
            this.datetimeDataGridViewTextBoxColumn.HeaderText = "Date_time";
            this.datetimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.datetimeDataGridViewTextBoxColumn.Name = "datetimeDataGridViewTextBoxColumn";
            this.datetimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.datetimeDataGridViewTextBoxColumn.Width = 97;
            // 
            // solvingthebackpackproblemBindingSource
            // 
            this.solvingthebackpackproblemBindingSource.DataMember = "Solving_the_backpack_problem";
            this.solvingthebackpackproblemBindingSource.DataSource = this.knapsack_problems_dbDataSet;
            // 
            // knapsack_problems_dbDataSet
            // 
            this.knapsack_problems_dbDataSet.DataSetName = "knapsack_problems_dbDataSet";
            this.knapsack_problems_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(347, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // solving_the_backpack_problemTableAdapter
            // 
            this.solving_the_backpack_problemTableAdapter.ClearBeforeFill = true;
            // 
            // show_db
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(812, 446);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "show_db";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отображение таблицы с результатами из БД";
            this.Load += new System.EventHandler(this.show_db_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solvingthebackpackproblemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapsack_problems_dbDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private knapsack_problems_dbDataSet knapsack_problems_dbDataSet;
        private System.Windows.Forms.BindingSource solvingthebackpackproblemBindingSource;
        private knapsack_problems_dbDataSetTableAdapters.Solving_the_backpack_problemTableAdapter solving_the_backpack_problemTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tasktypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backpackweightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberofitemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn answerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetimeDataGridViewTextBoxColumn;
    }
}