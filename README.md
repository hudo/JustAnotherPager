# Just Another Pager

Nothing fancy here, just a convinient pager that works nicely with Bootstrap. 

## How to use it (MVC 5 or 6)

Reference JA.Pagination.MVC5 (Full .NET) or MVC6 (Core) nuget, and with that there will be extension method for HtmlHelper available:

```cs
@Html.RenderPager(Model.CurrentPage, Model.TotalPages)  
```

or with overrides:

```cs
@Html.RenderPager(Model.CurrentPage, Model.TotalPages, 
    page => $"?page={page}",
    resourceOverrides: resource => { resource.Previous = "&laquo;"; resource.Next = "&raquo;"; })
```

## How to use it (direct call, without MVC)

This package usage doesn't require any ASP.NET dependencies. 
In your Razor view make sure you have variables: current page, total page count.   

```cs
@Html.Raw(Pager.Build(Model.CurrentPage, Model.TotalPages, page => $"?page={page}").Render())
```

or with overrides:

```cs
@Html.Raw(Pager.Build(Model.CurrentPage, Model.TotalPages, 
    page => $"?page={page}",
    resourceOverrides: resource => { resource.Previous = "&laquo;"; resource.Next = "&raquo;"; })
.Render())
```

Generated HTML will look like:

```html
<ul class="pagination">
	<li><a href="#" >&laquo;</a></li>
	<li class="active"><a href="?page=1" >1</a></li>
	<li><a href="?page=2" >2</a></li>
	<li><a href="?page=3" >3</a></li>
	<li class="disabled"><span>...</span></li>
	<li><a href="?page=20" >20</a></li>
	<li><a href="?page=2" >&raquo;</a></li>
</ul>
```

## Nuget

Package names: JA.Pagination, JA.Pagination.MVC5, JA.Pagination.MVC6   
https://www.nuget.org/packages/JA.Pagination  
https://www.nuget.org/packages/JA.Pagination.MVC5  
https://www.nuget.org/packages/JA.Pagination.MVC6   


## How to build solution

To build sample projects, packages needs to be created first. Build all projects except Samples, and execute Pack.bat from project roots. That will create local nuget repository with packages needed for sample projects.
