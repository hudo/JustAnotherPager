# Just Another Pager

Nothing fancy here, just a convinient pager that works nicely with Bootstrap. 

## How to use it

In your Razor view make sure you have variables: current page, total page count.   


     @Html.Raw(Pager.Build(Model.CurrentPage, Model.TotalPages, page => $"?page={page}",.Render())


or, if you want to override content:


     @Html.Raw(Pager.Build(Model.CurrentPage, Model.TotalPages, page => $"?page={page}",
            resourceOverrides: resource => { resource.Previous = "&laquo;"; resource.Next = "&raquo;"; })
        .Render())


Generated HTML will look like:

     <ul class="pagination">	   <li><a href="#" >&laquo;</a></li>	   <li class="active"><a href="?page=1" >1</a></li>	   <li><a href="?page=2" >2</a></li>	   <li><a href="?page=3" >3</a></li>	   <li class="disabled"><span>...</span></li>	   <li><a href="?page=20" >20</a></li>	   <li><a href="?page=2" >&raquo;</a></li>	 </ul>