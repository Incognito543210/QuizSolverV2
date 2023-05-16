using QuizSolverV2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace QuizSolverV2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {


        private readonly MainModel mainModel;

        

        //Load data
        #region
        public ObservableCollection<Quiz> QuizList { get; set; }
        public ObservableCollection<Quiz> QuizListforQuestion { get; set; }


        public MainViewModel()
        {
            mainModel = new MainModel();
            QuizList = new ObservableCollection<Quiz>(mainModel.loadQuizList());
            isComboBoxEnabled = true;
            IsButtonEnabledAnswer = false;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;

        }

        #endregion
        //Choice quiz and load answer, bloc that user can choice more than one quiz
        #region
        private Quiz _selectedQuiz = new Quiz();

        public Quiz SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                _selectedQuiz = value;
                onPropertyChanged(nameof(SelectedQuiz));
                onPropertyChanged(nameof(IsQuizSelected));
                IsButtonEnabled = true;
            }
        }

        public bool IsQuizSelected => SelectedQuiz != null;

        public ICommand ShowSelectedQuizCommand => new RelayCommand(ShowSelectedQuiz);

        private ObservableCollection<Questions> _questions;
        public ObservableCollection<Questions> Questions
        {

            get { return _questions; }

            set
            {
                _questions = value;
                onPropertyChanged(nameof(Questions));

            }

        }




        private bool _isButtonEnabled;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                _isButtonEnabled = value;
                onPropertyChanged(nameof(IsButtonEnabled));
            }
        }



        #endregion
        //User can choice only one quiz
        #region
        private bool isComboBoxEnabled;
        public bool IsComboBoxEnabled
        {
            get => isComboBoxEnabled;
            set
            {
                isComboBoxEnabled = value;
                onPropertyChanged(nameof(IsComboBoxEnabled));
            }
        }




        private void ShowSelectedQuiz()
        {

            QuizList = new ObservableCollection<Quiz>(mainModel.loadQuestionAndAnswer(_selectedQuiz.id_quiz));
            MessageBox.Show($"Wybrano odpowiedź: {SelectedQuiz.name}");
            Questions = new ObservableCollection<Questions>(QuizList[_selectedQuiz.id_quiz].questions);
            IsComboBoxEnabled = false;
            IsButtonEnabled = false;
            IsButtonEnabledAnswer = true;
            _timer.Start();
        }
        #endregion

        //Time 
        #region
         
        private readonly DispatcherTimer _timer;
        private TimeSpan _elapsedTime;

        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
            set
            {
                _elapsedTime = value;
                onPropertyChanged(nameof(TimeDisplay));
            }
        }

        public string TimeDisplay
        {
            get { return _elapsedTime.ToString("hh\\:mm\\:ss"); }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ElapsedTime += TimeSpan.FromSeconds(1);
        }

        #endregion

        //Answer for quiz and points
        #region
        private bool _isAnswerASelected;

        public bool IsAnswerASelected
        {

            get { return _isAnswerASelected; }
            set { _isAnswerASelected = value;
                onPropertyChanged(nameof(IsAnswerASelected));
            }
        }

        private bool _isAnswerBSelected;

        public bool IsAnswerBSelected
        {

            get { return _isAnswerBSelected; }
            set
            {
                _isAnswerBSelected = value;
                onPropertyChanged(nameof(IsAnswerBSelected));
            }
        }




        private bool _isAnswerCSelected;

        public bool IsAnswerCSelected
        {

            get { return _isAnswerCSelected; }
            set
            {
                _isAnswerCSelected = value;
                onPropertyChanged(nameof(IsAnswerCSelected));
            }
        }



        private bool _isAnswerDSelected;

        public bool IsAnswerDSelected
        {

            get { return _isAnswerDSelected; }
            set
            {
                _isAnswerDSelected = value;
                onPropertyChanged(nameof(IsAnswerDSelected));
            }
        }





        public ICommand ShowSelectedAnswerCommand => new RelayCommand(ShowSelectedAnswer);



        private int _withQuestion=1;

        public int WithQuestion 
        {
            get => _withQuestion;
            set
            {
                _withQuestion = value;
                onPropertyChanged(nameof(WithQuestion));
            }
        }

        private int _points;

        public int Points
        {
            get => _points;
            set
            {
                _points = value;
                onPropertyChanged(nameof(Points));
            }
        }
        #endregion
        //Button for chceck answer
        #region
        private bool _isButtonEnabledAnswer;
        public bool IsButtonEnabledAnswer
        {
            get { return _isButtonEnabledAnswer; }
            set
            {
                _isButtonEnabledAnswer = value;
                onPropertyChanged(nameof(IsButtonEnabledAnswer));
            }
        }



       
        private void ShowSelectedAnswer()
        {
            
            if (IsAnswerASelected)
            {


                MessageBox.Show("Wybrano odpowiedz A");

                if (QuizList[SelectedQuiz.id_quiz].questions[WithQuestion - 1].corret_answer.Equals(QuizList[SelectedQuiz.id_quiz].questions[WithQuestion - 1].id_answerA))
                {
                    MessageBox.Show("Poprawna odpowiedz");
                    Points++;
                }
                else
                {
                    MessageBox.Show("Niestety nie poprawna odpowiedz");
                }
                
            }
            else if (IsAnswerBSelected)
            {


                MessageBox.Show("Wybrano odpowiedz B");

                if (QuizList[SelectedQuiz.id_quiz].questions[WithQuestion - 1].corret_answer.Equals(QuizList[SelectedQuiz.id_quiz].questions[WithQuestion - 1].id_answerB))
                {
                    MessageBox.Show("Poprawna odpowiedz");
                    Points++;
                }
                else
                {
                    MessageBox.Show("Niestety nie poprawna odpowiedz");
                }
                
            }

            else if (IsAnswerCSelected)
            {


                MessageBox.Show("Wybrano odpowiedz C");

                if (QuizList[SelectedQuiz.id_quiz].questions[WithQuestion - 1].corret_answer.Equals(QuizList[SelectedQuiz.id_quiz].questions[WithQuestion - 1].id_answerC))
                {
                    MessageBox.Show("Poprawna odpowiedz");
                    Points++;
                }
                else
                {
                    MessageBox.Show("Niestety nie poprawna odpowiedz");
                }

            }

            else if (IsAnswerDSelected)
            {


                MessageBox.Show("Wybrano odpowiedz D");

                if (QuizList[SelectedQuiz.id_quiz].questions[WithQuestion - 1].corret_answer.Equals(QuizList[SelectedQuiz.id_quiz].questions[WithQuestion - 1].id_answerD))
                {
                    MessageBox.Show("Poprawna odpowiedz");
                    Points++;
                }
                else
                {
                    MessageBox.Show("Niestety nie poprawna odpowiedz");
                }

            }

            else
            {
                MessageBox.Show("Wybierz odpowiedz");
                WithQuestion--;
            }

                if (WithQuestion == QuizList[SelectedQuiz.id_quiz].questions.Count)
                {
                    MessageBox.Show("Koniec quizu. Zdobyte punkty: " + Points);
                    IsButtonEnabledAnswer = false;
                _timer.Stop();
                WithQuestion--;
            }

            WithQuestion++;





        }

        #endregion






    }
}
