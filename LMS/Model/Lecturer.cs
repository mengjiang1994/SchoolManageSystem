using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LMS.Model
{
    public class Lecturer
    {

        public static Lecturer CreateNewLecturerFromBody(Lecturer lecturerFromBody)
        {
            Lecturer newLecturer = new Lecturer();

            newLecturer.Name = lecturerFromBody.Name;
            newLecturer.LecturerDetail = lecturerFromBody.LecturerDetail;
            //Mapping value in here
            //Ignore the ID
            return newLecturer;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public LecturerDetail LecturerDetail { get; set; }

        [JsonProperty("Teaching")]
        public ICollection<Teaching> Teachings { get; set; }

        public Lecturer()
        {
        }
    }
}



