using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationDesktop.Services;
using ApplicationDesktop.Models;
using Newtonsoft.Json;
using System.IO;

namespace ApplicationDesktop
{
    public partial class HomePage : Form
    {
        private readonly ApiService _apiService;
        private bool isLoadingData;
        private int? SelectedCycleId; // Store currently selected cycle's ID
        string exePath = Application.StartupPath;

        public HomePage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void HomePage_Load(object sender, EventArgs e)
        {
            isLoadingData = true;

            var cycles = await _apiService.GetAllCyclesAsync();

            // detach the binding source
            this.dgvCycles.DataSource = null;

            foreach (var cycle in cycles)
            {
                cycleBindingSource.Add(cycle);
            }

            // reattach the binding source
            this.dgvCycles.DataSource = this.cycleBindingSource;

            isLoadingData = false;
        }

        // Button Click Event Handler
        private async void AddCycleButton_Click(object sender, EventArgs e)
        {
            // Assuming that the new row is the last row in the DataGridView
            DataGridViewRow newRow = dgvCycles.Rows[dgvCycles.Rows.Count - 2];
            int sectionNumber = int.Parse(newRow.Cells["sectionNumberDataGridViewTextBoxColumn"].Value.ToString());
            string name = newRow.Cells["nameCycleDataGridViewTextBoxColumn"].Value.ToString();
            DateTime startDate = DateTime.Parse(newRow.Cells["startDateDataGridViewTextBoxColumn"].Value.ToString());
            DateTime endDate = DateTime.Parse(newRow.Cells["endDateDataGridViewTextBoxColumn"].Value.ToString());

            Cycle newCycle = new Cycle(sectionNumber, name, startDate, endDate);  // Without ID
            Cycle addedCycle = await _apiService.AddCycleAsync(newCycle);

            if (addedCycle != null)
            {
                // Remove the user-created row from the DataGridView
                dgvCycles.Rows.Remove(newRow);

                // detach the binding source
                this.dgvCycles.DataSource = null;

                cycleBindingSource.Add(addedCycle);

                // reattach the binding source
                this.dgvCycles.DataSource = this.cycleBindingSource;
            }
        }

        private async void UpdateCycleButton_Click(object sender, EventArgs e)
        {
            if (dgvCycles.SelectedRows.Count == 0)
            {
                MessageBox.Show("No rows selected. Please select a row to update.");
                return;
            }

            // Assuming that the updated row is the selected row in the DataGridView
            DataGridViewRow updatedRow = dgvCycles.SelectedRows[0];
            int id = int.Parse(updatedRow.Cells["idCycleDataGridViewTextBoxColumn"].Value.ToString());
            int sectionNumber = int.Parse(updatedRow.Cells["sectionNumberDataGridViewTextBoxColumn"].Value.ToString());
            string name = updatedRow.Cells["nameCycleDataGridViewTextBoxColumn"].Value.ToString();
            DateTime startDate = DateTime.Parse(updatedRow.Cells["startDateDataGridViewTextBoxColumn"].Value.ToString());
            DateTime endDate = DateTime.Parse(updatedRow.Cells["endDateDataGridViewTextBoxColumn"].Value.ToString());

            Cycle updatedCycle = new Cycle(id, sectionNumber, name, startDate, endDate);  // With ID

            await _apiService.UpdateCycleAsync(id, updatedCycle);

            // Refresh DataGridView to show updated data
            dgvCycles.DataSource = null;

            cycleBindingSource.Clear();  // Clear existing items

            var cycles = await _apiService.GetAllCyclesAsync();
            foreach (var cycle in cycles)
            {
                cycleBindingSource.Add(cycle);
            }
            dgvCycles.DataSource = this.cycleBindingSource;
        }

        private async void DeleteCycleButton_Click(object sender, EventArgs e)
        {
            // Assuming that the row to delete is the selected row in the DataGridView
            DataGridViewRow rowToDelete = dgvCycles.SelectedRows[0];
            int id = int.Parse(rowToDelete.Cells["idCycleDataGridViewTextBoxColumn"].Value.ToString());

            bool isDeleted = await _apiService.DeleteCycleAsync(id);

            if (isDeleted)
            {
                // Remove the deleted row from the DataGridView
                dgvCycles.Rows.Remove(rowToDelete);
            }
            else
            {
                // You could show a message to the user here, indicating that the deletion was not successful.
            }
        }

        private async void dgvCycles_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoadingData)
            {
                return;
            }

            if (dgvCycles.SelectedRows.Count == 0)
            {
                return;
            }

            // Assuming that the updated row is the selected row in the DataGridView
            DataGridViewRow selectedRow = dgvCycles.SelectedRows[0];
            if (selectedRow.Cells["idCycleDataGridViewTextBoxColumn"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["idCycleDataGridViewTextBoxColumn"].Value.ToString()))
            {
                return;
            }

            int cycleId = int.Parse(selectedRow.Cells["idCycleDataGridViewTextBoxColumn"].Value.ToString());

            List<Student> students = await _apiService.GetStudentsByCycleIdAsync(cycleId);

            // Clear existing items
            dgvStudents.DataSource = null;

            // Create a new binding source
            BindingSource studentBindingSource = new BindingSource();

            // Add the students to the binding source
            foreach (var student in students)
            {
                studentBindingSource.Add(student);
            }

            // Attach the binding source to the DataGridView
            dgvStudents.DataSource = studentBindingSource;
            SelectedCycleId = cycleId; // Store the selected cycle's ID
        }

        private async void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (SelectedCycleId == null)
            {
                MessageBox.Show("No cycle selected. Please select a cycle first.");
                return;
            }

            // Assuming that the new student details are in the last row of the dgvStudents DataGridView
            DataGridViewRow newRow = dgvStudents.Rows[dgvStudents.Rows.Count - 2];
            string name = newRow.Cells["nameStudentDataGridViewTextBoxColumn1"].Value.ToString();
            string lastName = newRow.Cells["lastNameStudentDataGridViewTextBoxColumn"].Value.ToString();
            DateTime birthDate = DateTime.Parse(newRow.Cells["birthDateDataGridViewTextBoxColumn"].Value.ToString());
            string email = newRow.Cells["emailDataGridViewTextBoxColumn"].Value.ToString();
            string phone = newRow.Cells["phoneDataGridViewTextBoxColumn"].Value.ToString();

            // Get the selected cycle ID
            DataGridViewRow selectedCycleRow = dgvCycles.SelectedRows[0];
            int cycleId = int.Parse(selectedCycleRow.Cells["idCycleDataGridViewTextBoxColumn"].Value.ToString());

            Student newStudent = new Student(name, lastName, birthDate, email, phone, cycleId); // Without ID
            StudentResponse addedStudentResponse = await _apiService.AddStudentAsync(newStudent);

            if (addedStudentResponse != null)
            {
                // Remove the user-created row from the DataGridView
                dgvStudents.Rows.Remove(newRow);

                // Add the new student to the students DataGridView
                this.dgvCycles.DataSource = null;
                // Create a new binding source for the student
                studentBindingSource.Add(addedStudentResponse.Student);
                this.dgvCycles.DataSource = this.cycleBindingSource;

                // Get the path to the application's root directory
                string exePath = Application.StartupPath;
                string filePath = Path.Combine(exePath, "Responses.txt");

                // Add the response to a text file
                string response = JsonConvert.SerializeObject(addedStudentResponse); // Serialize object to JSON string
                using (StreamWriter outputFile = new StreamWriter(filePath, true))
                {
                    outputFile.WriteLine(response + Environment.NewLine);
                }
                this.dgvCycles.DataSource = this.cycleBindingSource;
            }
        }

        private async void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvStudents.SelectedRows[0];
            int id = int.Parse(selectedRow.Cells["idStudentDataGridViewTextBoxColumn1"].Value.ToString());
            string name = selectedRow.Cells["nameStudentDataGridViewTextBoxColumn1"].Value.ToString();
            string lastName = selectedRow.Cells["lastNameStudentDataGridViewTextBoxColumn"].Value.ToString();
            DateTime birthDate = DateTime.Parse(selectedRow.Cells["birthDateDataGridViewTextBoxColumn"].Value.ToString());
            string email = selectedRow.Cells["emailDataGridViewTextBoxColumn"].Value.ToString();
            string phone = selectedRow.Cells["phoneDataGridViewTextBoxColumn"].Value.ToString();
            int cycleId = int.Parse(selectedRow.Cells["cycleIdDataGridViewTextBoxColumn"].Value.ToString());

            Student updatedStudent = new Student(id, name, lastName, birthDate, email, phone, cycleId);

            try
            {
                await _apiService.UpdateStudentAsync(id, updatedStudent);
                MessageBox.Show("Student updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}");
            }

        }

        private async void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            // Assuming that the student to be deleted is the one selected in the dgvStudents DataGridView
            DataGridViewRow selectedRow = dgvStudents.SelectedRows[0];
            int id = int.Parse(selectedRow.Cells["idStudentDataGridViewTextBoxColumn1"].Value.ToString());

            try
            {
                bool result = await _apiService.DeleteStudentAsync(id);

                if (result)
                {
                    // Remove the student from the DataGridView
                    dgvStudents.Rows.Remove(selectedRow);
                    MessageBox.Show("Student deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}");
            }

        }
    }
}
