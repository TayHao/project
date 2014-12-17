using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClasses
{
    [Serializable]
    public enum Faculty { UNDEFINED, FIOT, FEL, FPM, TEF, RTF, FMF, HTF, FSP, FMM, FL, FEA, FBT, FAKS, IFF, PBF, ZF };
    [Serializable]
    public enum EducationForm { UNDEFINED, DAILY, ABSENCE };
    [Serializable]
    public enum EducationLevel{ UNDEFINED, BACHELOR, SPECIALIST, MASTER };
    [Serializable]
    public enum AccountType { UNDEFINED, STUDENT, INSTRUCTOR };
    [Serializable]
    public class Project
    {
        public string theme;
        DateTime deadLine;
        DateTime acceptDate;
        public double penaltyPerCents;
        public int instructorId;
        public int id;
        public int[] studentIds;

        public Project(string themeStr, DateTime deadLineVal, DateTime acceptDateVal,
            double penaltyPerCentsVal, int instructorIdVal, int idVal, string idsStr)
        {
            setTheme(themeStr);
            setDeadLine(deadLineVal);
            setAcceptDate(acceptDateVal);
            setPenaltyPerCents(penaltyPerCentsVal);
            setInstructorId(instructorIdVal);
            setId(idVal);
            studentIds = parceIdsStr(idsStr);
        }
        public string getTheme() { return theme; }
        public DateTime getDeadLine() { return deadLine; }
        public DateTime getAcceptDate() { return acceptDate; }
        public double getPenaltyPerCents() { return penaltyPerCents; }
        public int getInstructorId() { return instructorId; }
        public int getId() { return id; }
        public int[] getStudentIds() { return studentIds; }

        public void setTheme(string themeStr) { theme = themeStr; }
        public void setDeadLine(DateTime deadLineVal) { deadLine = deadLineVal; }
        public void setAcceptDate(DateTime acceptDateVal) { acceptDate = acceptDateVal; }
        public void setPenaltyPerCents(double penaltyPerCentsVal) { penaltyPerCents = penaltyPerCentsVal; }
        public void setInstructorId(int instructorIdVal) { instructorId = instructorIdVal; }
        public void setId(int idVal) { id = idVal; }
        public static int[] parceIdsStr(string idsStr)
        {
            string[] idStrs = idsStr.Split(' ');
            int[] ids = new int[idStrs.Length];
            for (int i = 0; i < idStrs.Length; i++)
                ids[i] = Convert.ToInt32(idStrs[i]);
            return ids;
        }

    }
    [Serializable]
    public class LoginData
    {
        private string login;
        private string password;

        public LoginData(string loginStr = "", string passwordStr = "")
        {
            setLogin(loginStr);
            setPassword(passwordStr);
        }

        public string getLogin() { return login; }
        public string getPassword() { return password; }

        public int setPassword(string passStr)
        {
            int status = checkPassword(passStr);
            if (status == 0)
                password = passStr;

            return status;
        }
        public int setLogin(string loginStr)
        {
            int status = checkLogin(loginStr);
            if (status == 0)
                login = loginStr;

            return status;
        }

        private static int checkPassword(string passStr)
        {
            // TODO: check password string
            return 0;
        }
        private static int checkLogin(string passStr)
        {
            //TODO: check login string
            return 0;
        }
    }
    [Serializable]
    public class Account
    {
        private string name;
        private string surname;
        private string midname;
        private LoginData loginData;
        private int id;
        public AccountType accType;
        public string email;
        public string address;
        public string phoneNumber;

        public Account(LoginData loginDataInst, AccountType accTypeVal, string nameStr = "", string surnameStr = "", string midnameStr = "",
            int idVal = 0, string emailStr = "", string addressStr = "", string phoneStr = "")
        {
            setName(nameStr);
            setSurname(surnameStr);
            setMidname(midnameStr);
            loginData = loginDataInst;
            setId(idVal);
            setAccType(accTypeVal);
            setEmail(emailStr);
            setAddress(addressStr);
            setPhoneNumber(phoneStr);
        }
        public LoginData getLoginData() { return loginData; }
        public string getName() { return name; }
        public string getSurname() { return surname; }
        public string getMidname() { return midname; }
        public int getId() { return id; }
        public AccountType getAccType() { return accType; }
        public string getEmail() { return email; }
        public string getAddress() { return address; }
        public string getPhoneNumber() { return phoneNumber; }

        public void setLoginData(LoginData logData) { loginData = logData; }
        public int setName(string nameStr)
        {
            int status = checkString(nameStr);
            if (status == 0)
                name = nameStr;

            return status;
        }
        public int setSurname(string surnameStr)
        {
            int status = checkString(surnameStr);
            if (status == 0)
                surname = surnameStr;

            return status;
        }
        public int setMidname(string midnameStr)
        {
            int status = checkString(midnameStr);
            if (status == 0)
                midname = midnameStr;

            return status;
        }
        public void setId(int idVal) { id = idVal; }
        public void setAccType(AccountType accTypeVal) { accType = accTypeVal; }
        public void setEmail(string emailStr) { email = emailStr; }
        public void setAddress(string addressStr){ address = addressStr; }
        public void setPhoneNumber(string phoneStr) { phoneNumber = phoneStr; }
        private static int checkString(string str)
        {
            //TODO: check string
            return 0;
        }
    }
    [Serializable]
    public class StudentAccount : Account
    {
        private Faculty faculty;
        private string recordBookNum;
        private string specialityCode;
        private EducationForm educForm; // add accessors
        private string group; // add accessors
        private int[] markCount; // add accessors
        private EducationLevel educLevel; // add accessors
        private int[] projectIds;
        private Project[] projects;

        public StudentAccount(LoginData loginDataInst, AccountType accTypeVal, string nameStr = "", string surnameStr = "", string midnameStr = "",
            int idVal = 0, string emailStr = "", string addressStr = "", string phoneStr = "", Faculty facultyVal = Faculty.UNDEFINED,
            string recordBookVal = "", string specialityCodeVal = "", EducationForm educFormVal = EducationForm.UNDEFINED, string groupStr = "",
            int[] markCountArr = null, EducationLevel educLevelVal = EducationLevel.UNDEFINED, int[] projIdsArr = null, Project[] projs = null)
            : base(loginDataInst, accTypeVal, nameStr, surnameStr, midnameStr, idVal, emailStr, addressStr, phoneStr)
        {
            setFaculty(facultyVal);
            setRecordBookNum(recordBookVal);
            setSpecialityCodeVal(specialityCodeVal);
            setEducForm(educFormVal);
            setGroup(groupStr);
            setMarkCount(markCountArr);
            setEducLevel(educLevelVal);
            setProjectIds(projIdsArr);
            setProjects(projs);
        }

        public Faculty getFaculty() { return faculty; }
        public string getRecordBookNum() { return recordBookNum; }
        public string getSpecialityCode() { return specialityCode; }
        public EducationForm getEducForm() { return educForm; }
        public string getGroup() { return group; }
        public int[] getMarksCount() { return markCount; }
        public EducationLevel getEducationLevel() { return educLevel; }
        public int[] getProjectIds() { return projectIds; }
        public Project[] getProjects() { return projects; }

        public void setFaculty(Faculty facultyVal) { faculty = facultyVal; }
        public int setRecordBookNum(string recordBookVal)
        {
            int status = checkRecordBookNum(recordBookVal);
            if (status == 0)
                recordBookNum = recordBookVal;
            return status;
        }
        public int setSpecialityCodeVal(string specialityCodeVal)
        {
            int status = checkSpecialityCode(specialityCodeVal);
            if (status == 0)
                specialityCode = specialityCodeVal;
            return status;
        }
        public void setEducForm(EducationForm educFormVal) { educForm = educFormVal; }
        public void setGroup(string groupStr) { group = groupStr; }
        public void setMarkCount(int[] marks) { markCount = marks; }
        public void setEducLevel(EducationLevel educLevelVal) { educLevel = educLevelVal; }
        public void setProjectIds(int[] projectIdArr) { projectIds = projectIdArr; }
        public void setProjects(Project[] projectArr) { projects = projectArr; }
        private static int checkRecordBookNum(string recordBookVal)
        {
            // TODO: check record book number
            return 0;
        }
        private static int checkSpecialityCode(string specialityCodeVal)
        {
            // TODO: check spec. code
            return 0;
        }
        public double getAverageMark()
        {
            return (double)(3 * (markCount[0] + markCount[1]) + 4 * (markCount[2] + markCount[3]) +
                5 * markCount[4]) / (double)(markCount[0] + markCount[1] + markCount[2] + markCount[3]
                + markCount[4]);
        }
    }
    [Serializable]
    public class InstructorAccount : Account
    {
        private string position;
        private int academicStatus;
        private string academicLevel;
        private string workPlace;

        public InstructorAccount(LoginData loginDataInst, AccountType accTypeVal, string nameStr = "", string surnameStr = "", string midnameStr = "",
            int idVal = 0, string emailStr = "", string addressStr = "", string phoneStr = "", string positionStr = "",
            int academStatusStr = 0, string academLevelStr = "", string workPlaceStr = "")
            : base(loginDataInst, accTypeVal, nameStr, surnameStr, midnameStr, idVal, emailStr,
            addressStr, phoneStr)
        {
            setPosition(positionStr);
            setAcademicStatus(academStatusStr);
            setAcademicLevel(academLevelStr);
            setWorkPlace(workPlaceStr);
        }

        public string getPosition() { return position; }
        public int getAcademicStatus() { return academicStatus; }
        public string getAcademicLevel() { return academicLevel; }
        public string getWorkPlace() { return workPlace; }

        public void setPosition(string positionStr) { position = positionStr; }
        public void setAcademicStatus(int academicStatusStr) { academicStatus = academicStatusStr; }
        public void setAcademicLevel(string academicLevelStr) { academicLevel = academicLevelStr; }
        public void setWorkPlace(string workPlaceStr) { workPlace = workPlaceStr; }
    }
}
