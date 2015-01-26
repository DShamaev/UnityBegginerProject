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
         procedure display(radius:integer);virtual;
         procedure move(var xM,yM:integer);
         end;
     TSsavec = object(TTvarina)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     TLev = object(TSsavec)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     TAntilopa = object(TSsavec)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     TZebra = object(TSsavec)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     TPtici = object(TTvarina)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     TStraus = object(TPtici)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     TFlamingo = object(TPtici)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     Tsecretar = object(TPtici)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     TReptiles = object(TTvarina)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     TZmeya = object(TReptiles)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     TYasherica = object(TReptiles)
         constructor Init;
         procedure display(radius:integer);virtual;
         end;
     TKrokodil = object(TReptiles)
         constructor Init;
         procedure display(radius:integer);virtual;
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
    k:=-3;
    b:=3;
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
    k:=1;
    b:=-2;
end;

procedure TTvarina.put(color:integer;radius:integer);
begin
    setcolor(color);
    circle(x,y,radius);
    Setfillstyle(1,color);
    floodfill(x+1,y+1,color);
end;

procedure TTvarina.display;
begin
    if b1 then
    begin
        e:= imagesize(x-radius,y-radius,x+radius,y+radius);
        getmem(p,e);
    end;

    MOVE(X,Y);
end;

procedure TSsavec.display;
begin
    inherited display(radius);
    MOVE(X,Y);
    b1:=false;
end;

procedure TPtici.display;
begin
    inherited display(radius);
    MOVE(X,Y);
    b1:=false;
end;

procedure TReptiles.display;
begin
    inherited display(radius);
    MOVE(X,Y);
    b1:=false;
end;

procedure TLev.display;
begin
    if b1=false then
    begin
        putimage(x-radius,y-radius,p^,normalput);
    end;

    MOVE(X,Y);
    getimage(x-radius,y-radius,x+radius,y+radius,p^);
    inherited display(radius);
    b1:=false;
end;

procedure TAntilopa.display;
begin
    if b1=false then
    begin
        putimage(x-radius,y-radius,p^,normalput);
    end;
    
    MOVE(X,Y);
    getimage(x-radius,y-radius,x+radius,y+radius,p^);
    inherited display(radius);
    b1:=false;
end;

procedure TZebra.display;
begin
    if b1=false then
    begin
        putimage(x-radius,y-radius,p^,normalput);
    end;

    MOVE(X,Y);
    getimage(x-radius,y-radius,x+radius,y+radius,p^);
    inherited display(radius);
    b1:=false;
end;

procedure TStraus.display;
begin
    if b1=false then
    begin
        putimage(x-radius,y-radius,p^,normalput);
    end;

    MOVE(X,Y);
    getimage(x-radius,y-radius,x+radius,y+radius,p^);
    inherited display(radius);
    b1:=false;
end;

procedure TFlamingo.display;
begin
    inherited display(radius);
    MOVE(X,Y);
    getimage(x-radius,y-radius,x+radius,y+radius,p^);
    b1:=false;
end;

procedure Tsecretar.display;
begin
    inherited display(radius);
    MOVE(X,Y);
    getimage(x-radius,y-radius,x+radius,y+radius,p^);
    b1:=false;
end;

procedure TZmeya.display;
begin
    inherited display(radius);
    MOVE(X,Y);
    getimage(x-radius,y-radius,x+radius,y+radius,p^);
    b1:=false;
end;

procedure TKrokodil.display;
begin
    inherited display(radius);
    MOVE(X,Y);
    getimage(x-radius,y-radius,x+radius,y+radius,p^);
    b1:=false;
end;

procedure TYasherica.display;
begin
    inherited display(radius);
    MOVE(X,Y);
    getimage(x-radius,y-radius,x+radius,y+radius,p^);
    b1:=false;
end;

procedure TTvarina.move(var xM,yM:integer);
begin
    if (getpixel(xm,ym)<>green) or (getpixel(xm,ym)<>blue) then
    begin
        if (xm>=620) or (xm<=20)  then 
            k:=(-1)*k;
        if (ym>=460) or (ym<=20)  then 
            b:=(-1)*b;
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

    Lev.init;
    Antilopa.init;
    Zebra.init;
    Straus.init;
    Flamingo.init;
    Secretar.init;
    Zmeya.init;
    Krokodil.init;
    Yasherica.init;

    while not keypressed do
    begin
        Lev.display(2);Lev.put(12,2);
        Antilopa.display(2);Antilopa.put(3,2);
        Zebra.display(3);Zebra.put(4,3); 
        Straus.display(4);Straus.put(8,2); 
        Flamingo.display(3);Flamingo.put(11,3);
        Secretar.display(2);Secretar.put(12,2);
        Zmeya.display(2);Zmeya.put(6,2);
        Krokodil.display(3);Krokodil.put(2,3);
        Yasherica.display(2);Yasherica.put(7,2);
        delay(65000);
    end;

    readln;
    Closegraph;
end.