using QuizSolverV2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizSolverV2.Model
{
    public class Questions
    {

       public int id_question { get; set; }
        public string question { get; set; }
        public int corret_answer { get; set; }
        public int id_quiz { get; set; }

        public int question_number { get; set; }

        public String answerA { get; set; }
        public int id_answerA { get; set; }

        public String answerB { get; set; }
        public int id_answerB { get; set; }

        public String answerC { get; set; }
        public int id_answerC { get; set; }

        public String answerD { get; set; }
        public int id_answerD { get; set; }


    }
}
