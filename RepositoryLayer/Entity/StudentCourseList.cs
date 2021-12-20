using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer.Entity
{
    public class StudentCourseList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public StudentCourseList(List<T> items, int count, int pageIndex, int pageSize) 
                                                    //: base(items, count, pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }
       
        public static StudentCourseList<T> Create(List<T> items, int pageIndex, int pageSize)
        {
            var count =  items.Count();
            var item =  items.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return  new StudentCourseList<T>(item, count, pageIndex, pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }

}
