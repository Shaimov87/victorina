using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace victorina
{
     class Quiz
    {
        public Users user;
        public Answer[] answer;
        public int rating = 0;
        public string registration()
        {
            Console.WriteLine("\tPlease,enter login:pasword");
            string user = Console.ReadLine();
            return user;
        }
        public bool chekUsers(string user)
        {
            string checkUser=user;
            string[] usersStrs = File.ReadAllLines("users.dat");
            bool key = false;
            foreach(string usersStr in usersStrs)
            {
                int result=string.Compare(checkUser, usersStr);
                if (result == 0)
                    key = true;
            }
            if (key == false)
                Console.WriteLine("\tRegistration new user");
            if (key == true)
                Console.WriteLine("\tIdentification was successful");
            return key;
        }
        public int selectTopic()
        {
            
            Console.WriteLine("\tВыберите тему вопросов");
            Console.WriteLine("\tНажмите:");
            Console.WriteLine("\t1 История   2 Геграфия   3 Исскуство   4 Кино");
            int topic=Convert.ToInt32(Console.ReadLine());
            return topic;
        }

        public Quiz()
        {
            
            string user1=registration();
            string[] tokens = user1.Split(':');
            bool check = chekUsers(user1);
            if (check == false)
            {
                Users user = new Users(tokens[0], tokens[1]);
            }
            int topic = selectTopic();
            //if (topic == 1)
            //{
            //    Answer answer = new Answer(File.ReadAllText("history.dat"));
            //}
            string[] questionsStr = File.ReadAllLines($"{topic}quest.dat");
            string[] trueAnswerStr = File.ReadAllLines($"{topic}TrueAnswer.dat");
            string[] falseAnswerStr = File.ReadAllLines($"{topic}FalseAnswer.dat");
            Answer[] answer = new Answer[10];
            for(int i = 0; i < 10; i++)
            {
                answer[i] = new Answer(questionsStr[i], trueAnswerStr[i], falseAnswerStr[i]);
            }
            
        }
        public void start()
        {
            for(int i=0;i<10;i++)
            {
                Console.WriteLine(answer[i]);
                Console.WriteLine("\tВведите правильный ответ");
                string str = Console.ReadLine();
                int result = string.Compare(str, answer[i].trueAnswer);
                if (result == 0)
                {
                    Console.WriteLine("\tВерно");
                    rating++;
                }
                else
                    Console.WriteLine("\tНе верно");
            }
            Console.WriteLine($"\tКонец\tправильных ответов:{rating}");
        }
    }
}
