﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FInalProject_Group06
{
    
    public class TopicDAO
    {
        DBConnection dbConn = new DBConnection();
        public DataTable LoadTable()
        {
            string sqlStr = string.Format("SELECT *FROM Topic");
            return dbConn.LoadTable(sqlStr);
        }
        
        public void CreateTopic(Topic topic, string name, int major, string type, string description, string requirement,
            string student1, string student2, string student3, string instructor, string thesisLecturer, 
            int semester, int year)
        {
            if (name != null)
            {
                topic.name = name;
                topic.major = major;
                topic.type = type;
                topic.description = description;
                topic.requirement = requirement;
                topic.student1 = student1;
                topic.student2 = student2;
                topic.student3 = student3;
                topic.instructor = instructor;
                topic.thesisLecturer = thesisLecturer;
                topic.semester = semester;
                topic.year = year;
                topic.status = 0;
            }
        }
        public bool AddTopic(Topic topic)
        {
            string sqlStr = string.Format("INSERT INTO Topic(name, major, type,description,requirement, student1, student2, student3, instructor, thesisLecturer, semester, year, status) VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                topic.name, topic.major, topic.type, topic.description, topic.requirement, topic.student1, topic.student2, topic.student3, topic.instructor, topic.thesisLecturer, topic.semester, topic.year, topic.status);
            return dbConn.Execute(sqlStr);
        }
        public bool DeleteTopic(Topic topic)
        {
            string sqlStr = string.Format("DELETE FROM Topic WHERE Id = '{0}'", topic.id);
            return dbConn.Execute(sqlStr);

        }
        public bool EditTopic(Topic topic)
        {
            string sqlStr = string.Format("UPDATE Topic SET name = '{1}', major =  '{2}', type= '{3}',description= '{4}',requirement= '{5}', student1= '{6}', student2= '{7}', student3= '{8}', " +
                "instructor= '{9},thesisLecturer= '{10},semester= '{11},year= '{12},status= '{13}' WHERE id = {0}", 
                topic.id, topic.name, topic.major, topic.type,topic.description,topic.requirement, topic.student1, topic.student2, topic.student3, topic.instructor, topic.thesisLecturer, topic.semester, topic.year, topic.status);
            return dbConn.Execute(sqlStr);

        }

        public bool AddStudentTopic(Topic topic)
        {
            string sqlStr = string.Format("UPDATE Topic SET student1= '{1}', student2= '{2}', student3= '{3}'  WHERE id = {0}",
                topic.id,  topic.student1, topic.student2, topic.student3);
            return dbConn.Execute(sqlStr);

        }
        public bool ApproveTopic(Topic topic)
        {
            string sqlStr = string.Format("UPDATE Topic SET Status= '{1}' WHERE Id = {0}",topic.id,1);
            return dbConn.Execute(sqlStr);

        }

        public bool DisapproveTopic(Topic topic)
        {
            string sqlStr = string.Format("UPDATE Topic SET Status= '{1}' WHERE Id = {0}", topic.id,-1);
            return dbConn.Execute(sqlStr);

        }
        public bool FindTopic(Topic topic)
        {
            string sqlStr = string.Format("SELECT * FROM Topic WHERE Id = '{0}'", topic.id);
            var result = dbConn.ExecuteQuery(sqlStr);

            if (result != null && result.Count > 0)
            {
                topic.name = result[0]["Name"];
                topic.major = int.Parse(result[0]["Major"]);
                topic.type = result[0]["Type"];
                topic.description = result[0]["Description"];
                topic.requirement = result[0]["Requirement"];
                topic.student1 = result[0]["Student1"];
                topic.student2 = result[0]["Student2"];
                topic.student3 = result[0]["Student3"];
                topic.instructor = result[0]["Instructor"];
                topic.thesisLecturer = result[0]["ThesisLecturer"];
                topic.semester = int.Parse(result[0]["Semester"]);
                topic.year = int.Parse(result[0]["Year"]);
                topic.status = int.Parse(result[0]["Status"]);

                return true;
            }

            return false;
        }
        public bool FindTopicOnStudent(Topic topic,int studentId)
        {
            string sqlStr = string.Format("SELECT * FROM Topic WHERE Student1 = '{0}' OR Student2 = '{0}'", studentId);
            var result = dbConn.ExecuteQuery(sqlStr);

            if (result != null && result.Count > 0)
            {
                topic.name = result[0]["Name"];
                topic.major = int.Parse(result[0]["Major"]);
                topic.type = result[0]["Type"];
                topic.description = result[0]["Description"];
                topic.requirement = result[0]["Requirement"];
                topic.student1 = result[0]["Student1"];
                topic.student2 = result[0]["Student2"];
                topic.student3 = result[0]["Student3"];
                topic.instructor = result[0]["Instructor"];
                topic.thesisLecturer = result[0]["ThesisLecturer"];
                topic.semester = int.Parse(result[0]["Semester"]);
                topic.year = int.Parse(result[0]["Year"]);
                topic.status = int.Parse(result[0]["Status"]);

                return true;
            }

            return false;
        }


    }
}
