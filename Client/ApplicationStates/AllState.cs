namespace Client.ApplicationStates
{
    public class AllState
    {
        public Action? Action { get; set; }

        public bool ShowCompanyServices { get; set; }
        public bool ShowEmployee { get; set; }

        public void CompanyServicesClicked()
        {
            ResetAllDepartments();
            ShowCompanyServices = true;
            Action?.Invoke();
        }

        public void EmployeeClicked()
        {
            ResetAllDepartments();
            ShowEmployee = true;
            Action?.Invoke();
        }

        private void ResetAllDepartments()
        {
            ShowCompanyServices = false;
            ShowEmployee = false;
        }
    }
}