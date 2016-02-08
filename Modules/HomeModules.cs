using Nancy;
using Triangle.Objects;

namespace Triangle
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
    {
    return View["triangle_form.html"];
    };
    Get["/triangle_output"] = _ =>
    {
      TriangleVariables myTriangleVariables = new TriangleVariables
      {
        side1 = Request.Query["side1"],
        side2 = Request.Query["side2"],
        side3 = Request.Query["side3"],
    };
    string tType = "";

    if  (myTriangleVariables.side1 > (myTriangleVariables.side2 + myTriangleVariables.side3))
    {
       tType = "Not a triangle!";
    }
    else if (myTriangleVariables.side2 > (myTriangleVariables.side1 + myTriangleVariables.side3))
    {
       tType = "Not a triangle!";
    }
    else if (myTriangleVariables.side3 > (myTriangleVariables.side1 + myTriangleVariables.side2))
    {
       tType = "Not a triangle!";
    }
    else if ((myTriangleVariables.side1 == myTriangleVariables.side2) && (myTriangleVariables.side1 == myTriangleVariables.side3))
    {
       tType = "Equilateral";
    }
    else if ((myTriangleVariables.side1 != myTriangleVariables.side2) && (myTriangleVariables.side3 != myTriangleVariables.side2) && (myTriangleVariables.side3 != myTriangleVariables.side1)) {
       tType = "Scalene";
    }
    else {
       tType = "Isosceles";
    }
    TriangleReturn myTriangleReturn = new TriangleReturn
    {
      triangleType = tType
    };
      return View["triangle_output.html", myTriangleReturn];
    };
  }
}
}
