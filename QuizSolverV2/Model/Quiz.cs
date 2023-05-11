using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuizSolverV2.Model
{
     public class Quiz
    {
        public int id_quiz { get; set; }
        public string name { get; set; }
        public ObservableCollection<Questions>? questions { get; set; } = new ObservableCollection<Questions>();

    







    }
}
