﻿namespace API.Helpers;
public class PaginationParams
{
    private const int _maxPageSize = 20;
    private int _pageSize { get; set; } = 6;
    public int PageNumber { get; init; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > _maxPageSize ? _maxPageSize : value;
    }
}
