program savana;
uses graph,mir_sav,crt;
type
     Tserce = integer;
     TTvarina = object
         private
         x,y:integer;
         k,b:integer;
         b1,b2:boolean;
         e:byte;
         public
         constructor Init;
         procedure put(color:integer;radius:integer);virtual;
         procedure display;virtual;
         procedure move(var xM,yM:integer);
         end;
     TSsavec = object(TTvarina)
         constructor Init;
         procedure display;virtual;
         end;
     TLev = object(TSsavec)
         constructor Init;
         procedure display;virtual;
         end;
     TAntilopa = object(TSsavec)
         constructor Init;
         procedure display;virtual;
         end;
     TZebra = object(TSsavec)
         constructor Init;
         procedure display;virtual;
         end;
     TPtici = object(TTvarina)
         constructor Init;
         procedure display;virtual;
         end;
     TStraus = object(TPtici)
         constructor Init;
         procedure display;virtual;
         end;
     TFlamingo = object(TPtici)
         constructor Init;
         procedure display;virtual;
         end;
     Tsecretar = object(TPtici)
         constructor Init;
         procedure display;virtual;
         end;
     TReptiles = object(TTvarina)
         constructor Init;
         procedure display;virtual;
         end;
     TZmeya = object(TReptiles)
         constructor Init;
         procedure display;virtual;
         end;
     TYasherica = object(TReptiles)
         constructor Init;
         procedure display;virtual;
         end;
     TKrokodil = object(TReptiles)
         constructor Init;
         procedure display;virtual;
         end;

var i,gd,gm:integer;
    LEV:TLEV;
    ANTILOPA:TAntilopa;
    Zebra:Tzebra;
    Straus:Tstraus;
    Flamingo:TFlamingo;
    Secretar:Tsecretar;
    Zmeya:TZmeya;
    Krokodil:TKrokodil;
    Yasherica:TYasherica;
    p:pointer;
    x1,y1:integer;

constructor TTvarina.init;
begin
repeat
x:= random (300)+random (300)+15;
y:= random (200)+random (200)+15;
until (getpixel(x,y)<>blue) and (getpixel(x,y)<>green);
b1:=false;
b2:=false;
end;

constructor TSsavec.init;
begin
inherited init;
k:=0;
b:=0;
end;

constructor TPtici.init;
begin
inherited init;
k:=0;
b:=0;
end;

constructor TReptiles.init;
begin
inherited init;
k:=0;
b:=0;
end;

constructor TLev.init;
begin
inherited init;
k:=3;
b:=2;
end;
constructor TAntilopa.init;
begin
inherited init;
k:=-5;
b:=1;
end;
constructor TZebra.init;
begin
inherited init;
k:=-2;
b:=3;
end;

constructor TStraus.init;
begin
inherited init;
k:=-5;
b:=5;
end;
constructor TFlamingo.init;
begin
repeat
x:= random (300)+random (300)+20;
y:= random (200)+random (200)+20;
until getpixel(x,y)=blue;
k:=0;
b:=0;
b1:=false;
b2:=true;
end;
constructor Tsecretar.init;
begin
inherited init;
k:=5;
b:=5;
end;

constructor TZmeya.init;
begin
inherited init;
k:=-2;
b:=2;
end;
constructor TKrokodil.init;
begin
repeat
x:= random (300)+random (300)+20;
y:= random (200)+random (200)+20;
until getpixel(x,y)=blue;
k:=0;
b:=0;
b1:=false;
b2:=true;
end;
constructor TYasherica.init;
begin
inherited init;
k:=2;
b:=-2;
end;

procedure TTvarina.put(color:integer;radius:integer);
begin
if (getpixel(x+k,y+b)<>green) and (getpixel(x+k,y+b)<>blue) and (b2=false) then
begin
if b1 and (getpixel(x,y)<>green) and (getpixel(x,y)<>blue) then putimage(x-radius-1,y-radius-1,p^,normalput);
MOVE(X,Y);
if b1=false then
begin
e:= imagesize(x-radius-1,y-radius-1,x+radius+1,y+radius+1);
getmem(p,e);
getimage(x-radius-1,y-radius-1,x+radius+1,y+radius+1,p^);
end;
setcolor(color);
circle(x,y,radius);
Setfillstyle(1,color);
floodfill(x+1,y+1,color);
end
else
begin
if b2 then
begin
setcolor(color);
circle(x,y,radius);
Setfillstyle(1,color);
floodfill(x+1,y+1,color);
end;
MOVE(X,Y);
end;
b1:=true;
end;

procedure TTvarina.display;
begin
put(0,2);
end;
procedure TSsavec.display;
begin
put(0,2);
end;
procedure TPtici.display;
begin
put(0,2);
end;
procedure TReptiles.display;
begin
put(0,2);
end;

procedure TLev.display;
begin
put(12,2);
end;
procedure TAntilopa.display;
begin
put(6,2);
end;
procedure TZebra.display;
begin
put(15,2);
end;
procedure TStraus.display;
begin
put(13,2);
end;
procedure TFlamingo.display;
begin
put(5,2);
end;
procedure Tsecretar.display;
begin
put(6,2);
end;
procedure TZmeya.display;
begin
put(8,2);
end;
procedure TKrokodil.display;
begin
put(2,2);
end;
procedure TYasherica.display;
begin
put(10,2);
end;

procedure TTvarina.move(var xM,yM:integer);
begin
if (getpixel(xm+3*k,ym+3*b)<>green) and (getpixel(xm+3*k,ym+3*b)<>blue) then
begin
if (xm>=620) or (xm<=20)  then k:=(-1)*k;
if (ym>=460) or (ym<=20)  then b:=(-1)*b;
end
else
begin
k:=(-1)*k;
b:=(-1)*b;
end;
xm:=xm+k;
ym:=ym+b;
end;

begin
randomize;
gd:=detect;
Initgraph(gd,gm,'');
mir;

Lev.init;Antilopa.init;Zebra.init;Straus.init;Flamingo.init;
Secretar.init;Zmeya.init;Krokodil.init;Yasherica.init;

while not keypressed do
begin
Lev.display;
Antilopa.display;
Zebra.display;
Straus.display;
Flamingo.display;
Secretar.display;
Zmeya.display;
Krokodil.display;
Yasherica.display;
delay(10000);
end;

readln;
Closegraph;
end.

 
       