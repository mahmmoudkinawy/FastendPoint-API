﻿namespace API.Helpers;
public class PagerModel<T> : List<T>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }

    public PagerModel(
        IEnumerable<T> items,
        int pageNumber,
        int pageSize,
        int count)
    {
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalCount = count;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        AddRange(items);
    }

    public static async Task<PagerModel<T>> CreateAsync(
        IQueryable<T> source,
        int pageNumber,
        int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagerModel<T>(items, pageNumber, pageSize, count);
    }

}
