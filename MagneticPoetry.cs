using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MagneticPoetry
{
    public class MagneticPoetry
    {
        public static void Main()
        {
            string alphabet =
                "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            string top1000 =
                "the,to,of,a,I,and,is,in,that,it,for,you,on,be,have,are,with,not,this,or,as,was,but,at,in,from,by,an,if,they,about,would,can,one,my,will,all,do,has,like,there,me,writes,out,your,what,which,some,so,we,more,who,any,don't,up,get,am,if,just,he,no,other,people,know,only,their,than,this,it,think,when,them,been,time,had,were,and,note,his,should,use,then,also,good,how,could,way,very,into,much,make,because,these,does,see,may,as,even,you,two,want,most,new,many,well,such,really,first,same,those,our,now,say,work,being,used,too,anyone,here,where,over,what,right,but,problem,did,something,go,there,its,her,back,file,we,still,need,said,find,years,off,things,him,after,point,before,take,us,going,they,might,since,never,better,read,name,got,long,someone,she,can't,why,last,few,all,my,number,must,using,own,little,made,down,believe,he,so,while,line,both,around,another,through,for,thing,without,case,also,no,between,year,set,sure,probably,seems,enough,didn't,different,least,group,else,put,lot,direct,each,information,part,how,any,question,old,real,course,anything,fact,when,best,call,end,give,help,demand,at,is,come,called,person,either,under,run," +
                "try,done,though,always,list,look,news,world,thought,far,again,available,seen,quite,rather,to,less,life,one,day,problems,great,found,tell,women,every,ever,against,place,after,general,support,having,mean,above,heard,thanks,doing,able,high,from,next,state,change,book,now,talk,well,new,possible,please,bad,does,seem,man,following,send,example,several,isn't,computer,reason,that,trying,getting,you're,true,feel,wrong,type,let,stuff,keep,hard,left,idea,show,,says,power,remember,looking,why,until,game,local,non,ago,others,car,are,actually,that's,three,four,five,six,seven,eight,nine,ten,yet,message,away,machine,makes,interested,kind,large,sun,already,order,small,means,times,government,space,free,systems,running,first,second,third,fourth,fifth,however,money,nothing,home,level,music,start,issue,men,an,whether,given,test,user,big,pretty,address,once,misc.,agree,area,systems,include,write,mind,experience,memory,original,of,discussion,word,god,understand,matter,not,during,play,won't,standard,making,hand,days,copy,whole,do,human,works,interesting,just,cannot,yes,often,disk,side,maybe,these,nice,came,public,some,source,dave,guess,hourly," +
                "open,almost,full,buy,important,response,ask,return,simply,mark,went,hope,told,tried,wanted,story,process,saying,form,another,love,couple,gets,law,answer,live,city,since,comes,working,goes,country,sort,major,,haven't,everyone,cost,care,words,usually,company,water,opinions,reading,actually,instead,job,written,size,or,single,wouldn't,sense,pay,language,short,lines,then,questions,certainly,later,anyone,note,speed,saw,similar,week,can,light,friend,certain,difference,including,inf.,myself,responses,hear,within,however,add,correct,science,become,text,center,top,asked,error,known,perhaps,consider,sound,easy,price,started,especially,rights,stop,rest,everything,games,talking,local,recently,whatever,particular,half,low,simple,define,network,subject,except,ones,provide,class,fine,check,woman,took,months,interest,along,she,turn,due,clear,close,past,children,by,that's,phone,argument,various,result,although,opinion,worth,books,mode,don't,together,mine,there's,night,cause,wasn't,common,effect,position,maybe,series,head,likely,needs,itself,characters,situation,comments,unless,special,move,window,leave,allow,box,anyway,yes,sent,personal," +
                "aren't,self,mentioned,claim,taken,record,future,function,takes,uses,child,because,field,exactly,longer,view,four,most,themselves,happen,expect,room,changed,front,today,rate,business,they're,recent,with,movie,sources,numbers,main,needed,screen,wrote,anyway,early,product,friends,issues,performance,machines,your,research,board,lost,anybody,page,looks,amount,house,articles,wants,who,first,results,hit,wish,gun,knows,root,market,statement,necessary,fun,design,month,thinking,date,history,happened,hours,state,soon,break,death,card,names,lots,legal,choice,evidence,minutes,war,body,taking,even,ideas,yourself,perhaps,release,involved,format,useful,although,writing,chance,while,black,he's,assume,upon,kill,received,required,gov.,playing,output,sounds,weeks,cup,air,radio,willing,couldn't,changes,near,complete,here,reasons,played,vote,present,related,cases,tv,political,quality,currently,environment,string,learn,paper,color,parts,hold,advance,fast,force,rules,cut,considered,sometimes,difficult,outside,album,save,specific,completely,doubt,food,calls,folks,total,site,shows,normal,directly,white,among,coming,family,religion,supposed,solution," +
                "culture,dead,development,reasonable,create,decided,appropriate,knowledge,behind,exist,suggest,buffer,science,action,entire,below,has";
            string customWords = 
                "very,cool,Microsoft,OneNote,way,use,guess,everyone,application,program," +
                "c#,insert,picture,directory,magnetic,poetry";

            GenerateWords(alphabet);
            GenerateWords(top1000);
            GenerateWords(customWords);
        }

        private static void GenerateWords(string wordlist)
        {
            Array wordArray = wordlist.Split(',');
            
            Random r = new Random(337337);

            foreach(string word in wordArray)
            {
                int orientation = r.Next(8);
                GenerateGraphic(word, orientation - 4);
            }
        }

        private static void GenerateGraphic(string stringToDraw, int angle)
        {
            // Figure out how big the graphic should be
            Graphics tmpG = Graphics.FromImage(new Bitmap(1, 1));
            Font f = new Font("Linenstroke", 12);
            SizeF fontSize = tmpG.MeasureString(stringToDraw, f);
            tmpG.Dispose();

            int x = (int) fontSize.Width;
            int y = (int) fontSize.Height;
            
            // Make an appropriately-sized bitmap, accounting for the rotation
            double adjustedDegrees = Math.Abs(angle) / 360 * (2 * Math.PI);
            int extra = (int) (x * Math.Tan(adjustedDegrees));
            Bitmap b=new Bitmap(x + 10, y + 15 + extra);
            int drawPositionX = 5;
         
            int drawPositionY;
            if(angle < 0) drawPositionY = extra + 10;
            else drawPositionY = 5;

            // Link an image with the bitmap
            string basePath = System.IO.Path.GetTempPath();
            string fullTempPath = System.IO.Path.Combine(basePath, "magnetic_poetry_temp.jpeg");
            b.Save(fullTempPath, ImageFormat.Jpeg);
            System.Drawing.Image i = System.Drawing.Image.FromFile(fullTempPath);

            // Prepare the graphics context
            Graphics g = Graphics.FromImage(i);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);
            g.RotateTransform(angle);

            // Draw the word and rectangle
            g.DrawString(stringToDraw, f, new SolidBrush(Color.Black), drawPositionX, drawPositionY);
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), drawPositionX, drawPositionY, x, y);

            // Save the image
            string targetDirectory = System.IO.Path.Combine(
                System.Environment.CurrentDirectory,
                "Output");
            if (! System.IO.Directory.Exists(targetDirectory))
            {
                System.IO.Directory.CreateDirectory(targetDirectory);
            }

            i.Save(System.IO.Path.Combine(
                targetDirectory,
                stringToDraw + ".jpg"), ImageFormat.Jpeg);
            
            // Cleanup
            b.Dispose();
            i.Dispose();
            g.Dispose();
        }
    }
}
