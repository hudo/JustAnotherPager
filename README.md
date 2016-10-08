# Just Another Pager

Nothing fancy here, just a convinient pager that works nicely with Bootstrap. 

## How to use it

In your Razor view make sure you have variables: current page, total page count.   


     @Html.Raw(Pager.Build(Model.CurrentPage, Model.TotalPages, page => $"?page={page}",.Render())


or, if you want to override content:


     @Html.Raw(Pager.Build(Model.CurrentPage, Model.TotalPages, page => $"?page={page}",
            resourceOverrides: resource => { resource.Previous = "&laquo;"; resource.Next = "&raquo;"; })
        .Render())