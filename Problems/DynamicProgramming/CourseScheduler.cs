using System;
using System.Linq;
using System.Collections.Generic;
namespace Problems.DynamicProgramming
{
    public class CourseScheduler
    {
        public int ScheduleCourse(int[][] courses)
        {
            var valid_courses = new List<int[]>();

            foreach (var course in courses)
            {
                if (course[1] >= course[0])
                    valid_courses.Add(course);
            }


            if (valid_courses.Count() == 0)
                return 0;


            valid_courses = valid_courses.OrderBy(u => u[1]).ToList();
            var N = valid_courses.Count();

            var result = 1;
            var prev_min_dur_at_index = new List<int>();
            foreach (var course in valid_courses)
            {
                if (prev_min_dur_at_index.Count() == 0)
                {
                    prev_min_dur_at_index.Add(course[0]);
                    continue;
                }

                if (course[0] < prev_min_dur_at_index[prev_min_dur_at_index.Count() - 1])
                    prev_min_dur_at_index.Add(course[0]);
                else
                    prev_min_dur_at_index.Add(prev_min_dur_at_index[prev_min_dur_at_index.Count() - 1]);
            }


            for (var i = 1; i < N; i++)
            {
                var next_min_dur_at_index = new List<int>();
                for (var j = i; j < N; j++)
                {
                    var course_dur = valid_courses[j][0];
                    var course_last_day = valid_courses[j][1];

                    var prev_cnt = i;
                    var prev_last_day = prev_min_dur_at_index[j - i];

                    var item = 100000000;
                    if ((prev_last_day + course_dur) <= course_last_day)
                    {
                        item = prev_last_day + course_dur;
                        result = Math.Max(result, prev_cnt + 1);
                    }


                    if (next_min_dur_at_index.Count() == 0)
                    {
                        next_min_dur_at_index.Add(item);
                        continue;
                    }

                    if (item < next_min_dur_at_index[next_min_dur_at_index.Count() - 1])
                        next_min_dur_at_index.Add(item);
                    else
                        next_min_dur_at_index.Add(next_min_dur_at_index[-1]);
                }
                prev_min_dur_at_index = next_min_dur_at_index;
            }
            return result;
        }
    }
}
