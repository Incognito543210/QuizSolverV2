using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace QuizSolverV2.Model
{
    internal class MainModel
    {
        string connectionString = "Data Source=QuizDataBase.db";
        public List<Quiz> quizList = new List<Quiz>();
       
        private EncryptionHelper _encryptionHelper = new EncryptionHelper(); 
        
        public List<Quiz> loadQuizList()
        {  
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM quizTable";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Quiz quiz = new Quiz();
                        quiz.id_quiz = Convert.ToInt32(row["id_quiz"]);
                        quiz.name = row["name"].ToString();
                        Console.WriteLine(quiz.id_quiz + quiz.name);
                        quizList.Add(quiz);
                    }

                }
                connection.Close();
            }
            return quizList;
        }

        public int positionQuizInQuizList(int id_quizParametr = 1)
        {
            
            int positionOfChoiceQuizInQuizList = quizList.FindIndex(quiz => quiz.id_quiz == id_quizParametr);
            return positionOfChoiceQuizInQuizList;
        }

        public List<Quiz> loadQuestionAndAnswer(int id_quizParametr = 1)
        {
              
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string queryQuestion = "SELECT * FROM questionTable where id_quiz =@param_id_quiz";
                int positionOfChoiceQuizInQuizList = quizList.FindIndex(quiz => quiz.id_quiz == id_quizParametr);

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(queryQuestion, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@param_id_quiz", id_quizParametr.ToString()) ;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    int numerOfQuestion = 1;

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Questions question = new Questions();

                        question.question_number = numerOfQuestion;
                        question.id_question = Convert.ToInt32(row["id_question"]);
                        question.question = row["content"].ToString();
                        question.corret_answer = _encryptionHelper.DecryptInt(Convert.ToInt32(row["id_correctAnswer"]));
                        question.id_quiz = Convert.ToInt32(row["id_quiz"]);
                        Console.WriteLine(question.id_question + question.question + question.corret_answer + question.id_quiz);


                        


                        quizList[positionOfChoiceQuizInQuizList].questions.Add(question);
                        numerOfQuestion++;
                    }

                }

                string queryAnswer = "SELECT * FROM answerTable where id_question =@param_id_question";

                for (int i = 0; i< quizList[positionOfChoiceQuizInQuizList].questions.Count; i++)
                {



                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(queryAnswer, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@param_id_question", quizList[positionOfChoiceQuizInQuizList].questions[i].id_question.ToString());
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        int j = 0;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Answer anserws = new Answer();

                            anserws.content = row["contentAnswer"].ToString();
                            anserws.id_answer = Convert.ToInt32(row["id_answer"]);
                            anserws.id_question = Convert.ToInt32(row["id_question"]);
                           

                           
                            if (j == 0)
                            {
                                quizList[positionOfChoiceQuizInQuizList].questions[i].answerA= anserws.content;
                                quizList[positionOfChoiceQuizInQuizList].questions[i].id_answerA = anserws.id_answer;
                            }
                            if (j == 1)
                            {
                                quizList[positionOfChoiceQuizInQuizList].questions[i].answerB= anserws.content; ;
                                quizList[positionOfChoiceQuizInQuizList].questions[i].id_answerB = anserws.id_answer;
                            }
                            if (j == 2)
                            {
                                quizList[positionOfChoiceQuizInQuizList].questions[i].answerC = anserws.content; ;
                                quizList[positionOfChoiceQuizInQuizList].questions[i].id_answerC = anserws.id_answer;
                            }
                            if (j == 3)
                            {
                                quizList[positionOfChoiceQuizInQuizList].questions[i].answerD = anserws.content; ;
                                quizList[positionOfChoiceQuizInQuizList].questions[i].id_answerD = anserws.id_answer;
                            }
                            j++;
                        }

                    }


                }


                connection.Close();
            }
            return quizList;
        }

      

















    }
}
