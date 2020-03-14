using System;

namespace Tour.Domain.Core
{

    public interface IPagingFilterOptions
    {
        int Page { get; set; }
        int PerPage { get; set; }

    }

    public class PagingFilterOptions : IPagingFilterOptions
    {
        public virtual int Page { get; set; } = 1;
        public virtual int PerPage { get; set; } = 10;

    }

    public interface IDateFilterOptions
    {
        DateTime? FromDate { get; set; }
        DateTime? ToDate { get; set; }

    }

    public class DateFilterOptions : PagingFilterOptions, IDateFilterOptions
    {
        public virtual DateTime? FromDate { get; set; }
        public virtual DateTime? ToDate { get; set; }

    }
}