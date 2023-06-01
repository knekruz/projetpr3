namespace ApplicationDesktop
{
    partial class HomePage
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
            this.dgvCycles = new System.Windows.Forms.DataGridView();
            this.idCycleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectionNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCycleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new ApplicationDesktop.Models.DataGridViewCalendarColumn();
            this.endDateDataGridViewTextBoxColumn = new ApplicationDesktop.Models.DataGridViewCalendarColumn();
            this.cycleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AddCycleButton = new System.Windows.Forms.Button();
            this.UpdateCycleButton = new System.Windows.Forms.Button();
            this.DeleteCycleButton = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.idStudentDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameStudentDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameStudentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthDateDataGridViewTextBoxColumn = new ApplicationDesktop.Models.DataGridViewCalendarColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cycleIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnUpdateStudent = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCycles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cycleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCycles
            // 
            this.dgvCycles.AutoGenerateColumns = false;
            this.dgvCycles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCycles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCycleDataGridViewTextBoxColumn,
            this.sectionNumberDataGridViewTextBoxColumn,
            this.nameCycleDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn});
            this.dgvCycles.DataSource = this.cycleBindingSource;
            this.dgvCycles.Location = new System.Drawing.Point(12, 29);
            this.dgvCycles.Name = "dgvCycles";
            this.dgvCycles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCycles.Size = new System.Drawing.Size(445, 276);
            this.dgvCycles.TabIndex = 0;
            this.dgvCycles.SelectionChanged += new System.EventHandler(this.dgvCycles_SelectionChanged);
            // 
            // idCycleDataGridViewTextBoxColumn
            // 
            this.idCycleDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idCycleDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idCycleDataGridViewTextBoxColumn.Name = "idCycleDataGridViewTextBoxColumn";
            this.idCycleDataGridViewTextBoxColumn.Visible = false;
            // 
            // sectionNumberDataGridViewTextBoxColumn
            // 
            this.sectionNumberDataGridViewTextBoxColumn.DataPropertyName = "SectionNumber";
            this.sectionNumberDataGridViewTextBoxColumn.HeaderText = "SectionNumber";
            this.sectionNumberDataGridViewTextBoxColumn.Name = "sectionNumberDataGridViewTextBoxColumn";
            // 
            // nameCycleDataGridViewTextBoxColumn
            // 
            this.nameCycleDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameCycleDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameCycleDataGridViewTextBoxColumn.Name = "nameCycleDataGridViewTextBoxColumn";
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "StartDate";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.startDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "EndDate";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.endDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cycleBindingSource
            // 
            this.cycleBindingSource.DataSource = typeof(ApplicationDesktop.Models.Cycle);
            // 
            // AddCycleButton
            // 
            this.AddCycleButton.Location = new System.Drawing.Point(472, 29);
            this.AddCycleButton.Name = "AddCycleButton";
            this.AddCycleButton.Size = new System.Drawing.Size(75, 23);
            this.AddCycleButton.TabIndex = 1;
            this.AddCycleButton.Text = "Ajouter";
            this.AddCycleButton.UseVisualStyleBackColor = true;
            this.AddCycleButton.Click += new System.EventHandler(this.AddCycleButton_Click);
            // 
            // UpdateCycleButton
            // 
            this.UpdateCycleButton.Location = new System.Drawing.Point(472, 58);
            this.UpdateCycleButton.Name = "UpdateCycleButton";
            this.UpdateCycleButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateCycleButton.TabIndex = 2;
            this.UpdateCycleButton.Text = "Modifier";
            this.UpdateCycleButton.UseVisualStyleBackColor = true;
            this.UpdateCycleButton.Click += new System.EventHandler(this.UpdateCycleButton_Click);
            // 
            // DeleteCycleButton
            // 
            this.DeleteCycleButton.Location = new System.Drawing.Point(472, 87);
            this.DeleteCycleButton.Name = "DeleteCycleButton";
            this.DeleteCycleButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteCycleButton.TabIndex = 3;
            this.DeleteCycleButton.Text = "Supprimer";
            this.DeleteCycleButton.UseVisualStyleBackColor = true;
            this.DeleteCycleButton.Click += new System.EventHandler(this.DeleteCycleButton_Click);
            // 
            // dgvStudents
            // 
            this.dgvStudents.AutoGenerateColumns = false;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idStudentDataGridViewTextBoxColumn1,
            this.nameStudentDataGridViewTextBoxColumn1,
            this.lastNameStudentDataGridViewTextBoxColumn,
            this.birthDateDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.cycleIdDataGridViewTextBoxColumn});
            this.dgvStudents.DataSource = this.studentBindingSource;
            this.dgvStudents.Location = new System.Drawing.Point(12, 311);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(645, 298);
            this.dgvStudents.TabIndex = 4;
            // 
            // idStudentDataGridViewTextBoxColumn1
            // 
            this.idStudentDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idStudentDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idStudentDataGridViewTextBoxColumn1.Name = "idStudentDataGridViewTextBoxColumn1";
            this.idStudentDataGridViewTextBoxColumn1.Visible = false;
            // 
            // nameStudentDataGridViewTextBoxColumn1
            // 
            this.nameStudentDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameStudentDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameStudentDataGridViewTextBoxColumn1.Name = "nameStudentDataGridViewTextBoxColumn1";
            // 
            // lastNameStudentDataGridViewTextBoxColumn
            // 
            this.lastNameStudentDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameStudentDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameStudentDataGridViewTextBoxColumn.Name = "lastNameStudentDataGridViewTextBoxColumn";
            // 
            // birthDateDataGridViewTextBoxColumn
            // 
            this.birthDateDataGridViewTextBoxColumn.DataPropertyName = "BirthDate";
            this.birthDateDataGridViewTextBoxColumn.HeaderText = "BirthDate";
            this.birthDateDataGridViewTextBoxColumn.Name = "birthDateDataGridViewTextBoxColumn";
            this.birthDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.birthDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            // 
            // cycleIdDataGridViewTextBoxColumn
            // 
            this.cycleIdDataGridViewTextBoxColumn.DataPropertyName = "CycleId";
            this.cycleIdDataGridViewTextBoxColumn.HeaderText = "CycleId";
            this.cycleIdDataGridViewTextBoxColumn.Name = "cycleIdDataGridViewTextBoxColumn";
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(ApplicationDesktop.Models.Student);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(692, 311);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(75, 23);
            this.btnAddStudent.TabIndex = 5;
            this.btnAddStudent.Text = "Ajouter";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnUpdateStudent
            // 
            this.btnUpdateStudent.Location = new System.Drawing.Point(692, 340);
            this.btnUpdateStudent.Name = "btnUpdateStudent";
            this.btnUpdateStudent.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateStudent.TabIndex = 6;
            this.btnUpdateStudent.Text = "Modifier";
            this.btnUpdateStudent.UseVisualStyleBackColor = true;
            this.btnUpdateStudent.Click += new System.EventHandler(this.btnUpdateStudent_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Location = new System.Drawing.Point(692, 369);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteStudent.TabIndex = 7;
            this.btnDeleteStudent.Text = "Supprimer";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 621);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.btnUpdateStudent);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.DeleteCycleButton);
            this.Controls.Add(this.UpdateCycleButton);
            this.Controls.Add(this.AddCycleButton);
            this.Controls.Add(this.dgvCycles);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCycles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cycleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCycles;
        private System.Windows.Forms.BindingSource cycleBindingSource;
        private System.Windows.Forms.Button AddCycleButton;
        private System.Windows.Forms.Button UpdateCycleButton;
        private System.Windows.Forms.Button DeleteCycleButton;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnUpdateStudent;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCycleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectionNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCycleDataGridViewTextBoxColumn;
        private Models.DataGridViewCalendarColumn startDateDataGridViewTextBoxColumn;
        private Models.DataGridViewCalendarColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idStudentDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameStudentDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameStudentDataGridViewTextBoxColumn;
        private Models.DataGridViewCalendarColumn birthDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cycleIdDataGridViewTextBoxColumn;
    }
}