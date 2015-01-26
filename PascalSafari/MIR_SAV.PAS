unit mir_sav;
interface
procedure mir;
implementation
uses graph;
const n=20;
procedure mir;
var i:integer;
    x,y,r:integer;
begin
Setfillstyle(1,yellow);
floodfill(1,1,yellow);
setcolor(lightgray);
Setfillstyle(1,blue);
for i:=1 to (n div 3)+1 do
begin
x:=random(600)+15;
y:=random(440)+15;
r:=random(45)+5;
circle(x-3,y-3,r);
floodfill(x,y,lightgray);
end;
setcolor(darkgray);
Setfillstyle(1,green);
for i:=1 to n do
begin
x:=random(600)+15;
y:=random(440)+15;
r:=random(35)+15;
circle(x-3,y-3,r);
floodfill(x,y,darkgray);
end;
end;
begin
end.