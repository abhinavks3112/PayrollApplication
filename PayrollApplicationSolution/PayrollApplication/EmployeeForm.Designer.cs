namespace PayrollApplication
{
    partial class EmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.grpEmployeeInformation = new System.Windows.Forms.GroupBox();
            this.chkIsMember = new System.Windows.Forms.CheckBox();
            this.lblUnionMembership = new System.Windows.Forms.Label();
            this.grpMaritalStatus = new System.Windows.Forms.GroupBox();
            this.rdbSingle = new System.Windows.Forms.RadioButton();
            this.rdbMarried = new System.Windows.Forms.RadioButton();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.txtNationalInsuranceNumber = new System.Windows.Forms.TextBox();
            this.lblNationalInsuranceNumber = new System.Windows.Forms.Label();
            this.grpGender = new System.Windows.Forms.GroupBox();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.rdbMale = new System.Windows.Forms.RadioButton();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.grpEmployeeContactDetails = new System.Windows.Forms.GroupBox();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.grpEmployeeInformation.SuspendLayout();
            this.grpMaritalStatus.SuspendLayout();
            this.grpGender.SuspendLayout();
            this.grpEmployeeContactDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEmployeeInformation
            // 
            this.grpEmployeeInformation.Controls.Add(this.chkIsMember);
            this.grpEmployeeInformation.Controls.Add(this.lblUnionMembership);
            this.grpEmployeeInformation.Controls.Add(this.grpMaritalStatus);
            this.grpEmployeeInformation.Controls.Add(this.dtpDateOfBirth);
            this.grpEmployeeInformation.Controls.Add(this.lblDateOfBirth);
            this.grpEmployeeInformation.Controls.Add(this.txtNationalInsuranceNumber);
            this.grpEmployeeInformation.Controls.Add(this.lblNationalInsuranceNumber);
            this.grpEmployeeInformation.Controls.Add(this.grpGender);
            this.grpEmployeeInformation.Controls.Add(this.txtLastName);
            this.grpEmployeeInformation.Controls.Add(this.lblLastName);
            this.grpEmployeeInformation.Controls.Add(this.txtFirstName);
            this.grpEmployeeInformation.Controls.Add(this.lblFirstName);
            this.grpEmployeeInformation.Controls.Add(this.txtEmployeeID);
            this.grpEmployeeInformation.Controls.Add(this.lblEmployeeID);
            this.grpEmployeeInformation.Location = new System.Drawing.Point(46, 40);
            this.grpEmployeeInformation.Name = "grpEmployeeInformation";
            this.grpEmployeeInformation.Size = new System.Drawing.Size(346, 451);
            this.grpEmployeeInformation.TabIndex = 0;
            this.grpEmployeeInformation.TabStop = false;
            this.grpEmployeeInformation.Text = "Employee Information";
            this.grpEmployeeInformation.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkIsMember
            // 
            this.chkIsMember.AutoSize = true;
            this.chkIsMember.Location = new System.Drawing.Point(176, 406);
            this.chkIsMember.Name = "chkIsMember";
            this.chkIsMember.Size = new System.Drawing.Size(75, 17);
            this.chkIsMember.TabIndex = 14;
            this.chkIsMember.Text = "Is Member";
            this.chkIsMember.UseVisualStyleBackColor = true;
            // 
            // lblUnionMembership
            // 
            this.lblUnionMembership.AutoSize = true;
            this.lblUnionMembership.Location = new System.Drawing.Point(50, 407);
            this.lblUnionMembership.Name = "lblUnionMembership";
            this.lblUnionMembership.Size = new System.Drawing.Size(95, 13);
            this.lblUnionMembership.TabIndex = 12;
            this.lblUnionMembership.Text = "Union Membership";
            // 
            // grpMaritalStatus
            // 
            this.grpMaritalStatus.Controls.Add(this.rdbSingle);
            this.grpMaritalStatus.Controls.Add(this.rdbMarried);
            this.grpMaritalStatus.Location = new System.Drawing.Point(53, 325);
            this.grpMaritalStatus.Name = "grpMaritalStatus";
            this.grpMaritalStatus.Size = new System.Drawing.Size(223, 59);
            this.grpMaritalStatus.TabIndex = 7;
            this.grpMaritalStatus.TabStop = false;
            this.grpMaritalStatus.Text = "Marital Status";
            // 
            // rdbSingle
            // 
            this.rdbSingle.AutoSize = true;
            this.rdbSingle.Location = new System.Drawing.Point(123, 28);
            this.rdbSingle.Name = "rdbSingle";
            this.rdbSingle.Size = new System.Drawing.Size(54, 17);
            this.rdbSingle.TabIndex = 1;
            this.rdbSingle.TabStop = true;
            this.rdbSingle.Text = "Single";
            this.rdbSingle.UseVisualStyleBackColor = true;
            // 
            // rdbMarried
            // 
            this.rdbMarried.AutoSize = true;
            this.rdbMarried.Location = new System.Drawing.Point(48, 28);
            this.rdbMarried.Name = "rdbMarried";
            this.rdbMarried.Size = new System.Drawing.Size(60, 17);
            this.rdbMarried.TabIndex = 0;
            this.rdbMarried.TabStop = true;
            this.rdbMarried.Text = "Married";
            this.rdbMarried.UseVisualStyleBackColor = true;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(176, 285);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(100, 20);
            this.dtpDateOfBirth.TabIndex = 11;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(50, 285);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(68, 13);
            this.lblDateOfBirth.TabIndex = 9;
            this.lblDateOfBirth.Text = "Date Of Birth";
            this.lblDateOfBirth.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtNationalInsuranceNumber
            // 
            this.txtNationalInsuranceNumber.Location = new System.Drawing.Point(176, 250);
            this.txtNationalInsuranceNumber.Name = "txtNationalInsuranceNumber";
            this.txtNationalInsuranceNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNationalInsuranceNumber.TabIndex = 8;
            this.txtNationalInsuranceNumber.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblNationalInsuranceNumber
            // 
            this.lblNationalInsuranceNumber.AutoSize = true;
            this.lblNationalInsuranceNumber.Location = new System.Drawing.Point(50, 253);
            this.lblNationalInsuranceNumber.Name = "lblNationalInsuranceNumber";
            this.lblNationalInsuranceNumber.Size = new System.Drawing.Size(116, 13);
            this.lblNationalInsuranceNumber.TabIndex = 7;
            this.lblNationalInsuranceNumber.Text = "National Insurance No.";
            this.lblNationalInsuranceNumber.Click += new System.EventHandler(this.label1_Click);
            // 
            // grpGender
            // 
            this.grpGender.Controls.Add(this.rdbFemale);
            this.grpGender.Controls.Add(this.rdbMale);
            this.grpGender.Location = new System.Drawing.Point(53, 166);
            this.grpGender.Name = "grpGender";
            this.grpGender.Size = new System.Drawing.Size(223, 59);
            this.grpGender.TabIndex = 6;
            this.grpGender.TabStop = false;
            this.grpGender.Text = "Gender";
            this.grpGender.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Location = new System.Drawing.Point(123, 28);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(59, 17);
            this.rdbFemale.TabIndex = 1;
            this.rdbFemale.TabStop = true;
            this.rdbFemale.Text = "Female";
            this.rdbFemale.UseVisualStyleBackColor = true;
            this.rdbFemale.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Location = new System.Drawing.Point(48, 28);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(48, 17);
            this.rdbMale.TabIndex = 0;
            this.rdbMale.TabStop = true;
            this.rdbMale.Text = "Male";
            this.rdbMale.UseVisualStyleBackColor = true;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(176, 124);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 5;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(50, 127);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(176, 84);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(50, 87);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(54, 13);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "FirstName";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(176, 42);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(100, 20);
            this.txtEmployeeID.TabIndex = 1;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Location = new System.Drawing.Point(50, 45);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(64, 13);
            this.lblEmployeeID.TabIndex = 0;
            this.lblEmployeeID.Text = "EmployeeID";
            // 
            // grpEmployeeContactDetails
            // 
            this.grpEmployeeContactDetails.Controls.Add(this.cmbCountry);
            this.grpEmployeeContactDetails.Controls.Add(this.txtNotes);
            this.grpEmployeeContactDetails.Controls.Add(this.lblNotes);
            this.grpEmployeeContactDetails.Controls.Add(this.textBox6);
            this.grpEmployeeContactDetails.Controls.Add(this.lblEmailAddress);
            this.grpEmployeeContactDetails.Controls.Add(this.txtPhoneNumber);
            this.grpEmployeeContactDetails.Controls.Add(this.lblPhoneNumber);
            this.grpEmployeeContactDetails.Controls.Add(this.lblCountry);
            this.grpEmployeeContactDetails.Controls.Add(this.txtPostCode);
            this.grpEmployeeContactDetails.Controls.Add(this.lblPostCode);
            this.grpEmployeeContactDetails.Controls.Add(this.txtCity);
            this.grpEmployeeContactDetails.Controls.Add(this.lblCity);
            this.grpEmployeeContactDetails.Controls.Add(this.txtAddress);
            this.grpEmployeeContactDetails.Controls.Add(this.lblAddress);
            this.grpEmployeeContactDetails.Location = new System.Drawing.Point(417, 40);
            this.grpEmployeeContactDetails.Name = "grpEmployeeContactDetails";
            this.grpEmployeeContactDetails.Size = new System.Drawing.Size(362, 451);
            this.grpEmployeeContactDetails.TabIndex = 1;
            this.grpEmployeeContactDetails.TabStop = false;
            this.grpEmployeeContactDetails.Text = "Employee Contact Details";
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Items.AddRange(new object[] {
            "Select a Country.....",
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Antigua & Deps",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bhutan",
            "Bolivia",
            "Bosnia Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Burkina",
            "Burundi",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cape Verde",
            "Central African Rep",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Comoros",
            "Congo",
            "Congo {Democratic Rep}",
            "Costa Rica",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "East Timor",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Greece",
            "Grenada",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland {Republic}",
            "Israel",
            "Italy",
            "Ivory Coast",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Korea North",
            "Korea South",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Macedonia",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Marshall Islands",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Micronesia",
            "Moldova",
            "Monaco",
            "Mongolia",
            "Montenegro",
            "Morocco",
            "Mozambique",
            "Myanmar, {Burma}",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "Norway",
            "Oman",
            "Pakistan",
            "Palau",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Poland",
            "Portugal",
            "Qatar",
            "Romania",
            "Russian Federation",
            "Rwanda",
            "St Kitts & Nevis",
            "St Lucia",
            "Saint Vincent & the Grenadines",
            "Samoa",
            "San Marino",
            "Sao Tome & Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South Sudan",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Suriname",
            "Swaziland",
            "Sweden",
            "Switzerland",
            "Syria",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Togo",
            "Tonga",
            "Trinidad & Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Tuvalu",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United States",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Vatican City",
            "Venezuela",
            "Vietnam",
            "Yemen",
            "Zambia",
            "Zimbabwe"});
            this.cmbCountry.Location = new System.Drawing.Point(177, 171);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(100, 21);
            this.cmbCountry.TabIndex = 16;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(177, 288);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(100, 131);
            this.txtNotes.TabIndex = 15;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(51, 291);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 14;
            this.lblNotes.Text = "Notes";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(177, 253);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 13;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(51, 256);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(73, 13);
            this.lblEmailAddress.TabIndex = 12;
            this.lblEmailAddress.Text = "Email Address";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(177, 217);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.txtPhoneNumber.TabIndex = 11;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(51, 220);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(78, 13);
            this.lblPhoneNumber.TabIndex = 10;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(51, 174);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 8;
            this.lblCountry.Text = "Country";
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(177, 127);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(100, 20);
            this.txtPostCode.TabIndex = 7;
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Location = new System.Drawing.Point(51, 130);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(53, 13);
            this.lblPostCode.TabIndex = 6;
            this.lblPostCode.Text = "PostCode";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(177, 87);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 5;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(51, 90);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 4;
            this.lblCity.Text = "City";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(177, 45);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(51, 48);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(680, 515);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(135, 39);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.Color.Transparent;
            this.btnAddEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEmployee.Image")));
            this.btnAddEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddEmployee.Location = new System.Drawing.Point(12, 515);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAddEmployee.Size = new System.Drawing.Size(118, 39);
            this.btnAddEmployee.TabIndex = 3;
            this.btnAddEmployee.Text = "&Add Employee";
            this.btnAddEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUpdateEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateEmployee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateEmployee.Image")));
            this.btnUpdateEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateEmployee.Location = new System.Drawing.Point(136, 515);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(127, 39);
            this.btnUpdateEmployee.TabIndex = 4;
            this.btnUpdateEmployee.Text = "&Update Employee";
            this.btnUpdateEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateEmployee.UseVisualStyleBackColor = false;
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDeleteEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEmployee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteEmployee.Image")));
            this.btnDeleteEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteEmployee.Location = new System.Drawing.Point(269, 515);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(123, 39);
            this.btnDeleteEmployee.TabIndex = 5;
            this.btnDeleteEmployee.Text = "&Delete Employee";
            this.btnDeleteEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteEmployee.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Gainsboro;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(398, 515);
            this.btnReset.Name = "btnReset";
            this.btnReset.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReset.Size = new System.Drawing.Size(135, 39);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(539, 515);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnPreview.Size = new System.Drawing.Size(135, 39);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(843, 579);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.btnUpdateEmployee);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grpEmployeeContactDetails);
            this.Controls.Add(this.grpEmployeeInformation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmployeeForm";
            this.Text = "Manage Employees";
            this.grpEmployeeInformation.ResumeLayout(false);
            this.grpEmployeeInformation.PerformLayout();
            this.grpMaritalStatus.ResumeLayout(false);
            this.grpMaritalStatus.PerformLayout();
            this.grpGender.ResumeLayout(false);
            this.grpGender.PerformLayout();
            this.grpEmployeeContactDetails.ResumeLayout(false);
            this.grpEmployeeContactDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEmployeeInformation;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.GroupBox grpEmployeeContactDetails;
        private System.Windows.Forms.GroupBox grpGender;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.RadioButton rdbFemale;
        private System.Windows.Forms.RadioButton rdbMale;
        private System.Windows.Forms.TextBox txtNationalInsuranceNumber;
        private System.Windows.Forms.Label lblNationalInsuranceNumber;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.CheckBox chkIsMember;
        private System.Windows.Forms.Label lblUnionMembership;
        private System.Windows.Forms.GroupBox grpMaritalStatus;
        private System.Windows.Forms.RadioButton rdbSingle;
        private System.Windows.Forms.RadioButton rdbMarried;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.Label lblPostCode;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnUpdateEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPreview;
    }
}

