using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolverV2.Model
{
    public class Questions
    {


       public int id_question { get; set; }
        public string question { get; set; }
        public int corret_answer { get; set; }
        public int id_quiz { get; set; }
        public ObservableCollection<Answer>? answers { get; set; } = new ObservableCollection<Answer>();






    }
}
