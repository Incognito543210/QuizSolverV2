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

namespace QuizSolverV2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private readonly MainModel mainModel;

        //wczytanie danych
        public ObservableCollection<Quiz> QuizList { get; set; }
        public ObservableCollection<Quiz> QuizListforQuestion { get; set; }




        public MainViewModel()
        {
            mainModel = new MainModel();
            QuizList = new ObservableCollection<Quiz>(mainModel.loadQuizList());
            isComboBoxEnabled = true;
        }

        
        //wybor quizu i wczytanie odpowiedzi i zablokowanie mozliwosci aby wybrac więcej niz jeden quiz
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




        //nie mozna wybierac wiecej niz 1 quiz
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
                IsButtonEnabled=false;

        }




        //sprawdzanie odpowiedzi
        private ObservableCollection<Answer> _userAnswers = new ObservableCollection<Answer>();
        public ObservableCollection<Answer> UserAnswers
        {
            get { return _userAnswers; }
            set
            {
                _userAnswers = value;
                onPropertyChanged(nameof(UserAnswers));
            }
        }


        public ICommand CheckAnswersCommand => new RelayCommand(CheckAnswers);

        private void CheckAnswers()
        {
            MessageBox.Show($"Poprawnych odpowiedzi: {_userAnswers[0].content}");
        }






    }
}
