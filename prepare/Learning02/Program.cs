using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._title = "";
        job1._company = "";
        job1._startYear = 2010;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._title = "";
        job2._company = "";
        job2._startYear = 2010;
        job2._endYear = 2020;

        Resume myResume = new Resume();
        myResume._name = "";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}