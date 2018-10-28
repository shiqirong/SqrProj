/*
广州普金科技股份有限公司官网
财税事业研发部
技术支持“普金科技”
*/

/*首页下拉菜单效果*/
$(function(){
	$('.pjnav_down').hover(function(){
		$(this).find('div:eq(0)').slideDown(100);
	},function(){
		$(this).find('div:eq(0)').hide();
	})
	/*nav下拉选择*/
	$(".select_box").click(function(event){   
		event.stopPropagation();
		$(this).find(".option").toggle();
		$(this).parent().siblings().find(".option").hide();
	});
	$(document).click(function(event){
		var eo=$(event.target);
		if($(".select_box").is(":visible") && eo.attr("class")!="option" && !eo.parent(".option").length)
		$('.option').hide();									  
	});
	/*赋值给文本框*/
	$(".option a").click(function(){
		var value=$(this).text();
		$(this).parent().siblings(".select_txt").text(value);
	 });
	/*公告动态语录*/
	$('.pjmain_m_t ul li').hover(function(){
		$(this).addClass('pjmain_m_tclick').siblings().removeClass('pjmain_m_tclick');
		var dexia=$(this).index();
		$('.pjmain_m_c>dl:eq('+dexia+')').show().siblings().hide();
	})
	/*三级菜单*/
	$('.comdon_f_l').find('a').click(function(){
		$(this).addClass('comdon_float_click').parents('dd').siblings().find('a').removeClass('comdon_float_click');
		$(this).addClass('comdon_float_click').parents('dl').find('dt').find('a').removeClass('comdon_float_click');
		$(this).addClass('comdon_float_click').parents('dl').find('dd').find('a').removeClass('comdon_float_click');
		$(this).addClass('comdon_float_click').parents('dl').siblings().find('a').removeClass('comdon_float_click');
	});
	
//首页大图切换效果
var glume = function(banners_id, focus_id){
	this.$ctn = $('#' + banners_id);
	this.$focus = $('#' + focus_id);
	this.$adLis = null;
	this.$btns = null;
	this.switchSpeed = 5;//自动播放间隔(s)
	this.defOpacity = 1;
	this.crtIndex = 0;
	this.adLength = 0;
	this.timerSwitch = null;
	this.init();
};
glume.prototype = {
	fnNextIndex:function(){
		return (this.crtIndex >= this.adLength-1)?0:this.crtIndex+1;
	},
	//动画切换
	fnSwitch:function(toIndex){
		if(this.crtIndex==toIndex){return;}
		this.$adLis.css('zIndex', 0);
		this.$adLis.filter(':eq('+this.crtIndex+')').css('zIndex', 2);
		this.$adLis.filter(':eq('+toIndex+')').css('zIndex', 1);
		this.$btns.removeClass('on');
		this.$btns.filter(':eq('+toIndex+')').addClass('on');
		var me = this;

		$(this.$adLis[this.crtIndex]).animate({
			opacity: 0
		}, 1000, function() {
			me.crtIndex = toIndex;
			$(this).css({
				opacity: me.defOpacity,
				zIndex: 0
			});
		});
	},
	fnAutoPlay:function(){
		this.fnSwitch(this.fnNextIndex());
	},
	fnPlay:function(){
		var me = this;
		me.timerSwitch = window.setInterval(function() {
			me.fnAutoPlay();
		},me.switchSpeed*1000);
	},
	fnStopPlay:function(){
		window.clearTimeout(this.timerSwitch);
		this.timerSwitch = null;
	},

	init:function(){
		this.$adLis = this.$ctn.children();
		this.$btns = this.$focus.children();
		this.adLength = this.$adLis.length;

		var me = this;
		//点击切换
		this.$focus.on('click', 'a', function(e) {
			e.preventDefault();
			var index = parseInt($(this).attr('data-index'), 10)
			me.fnSwitch(index);
		});
		this.$adLis.filter(':eq('+ this.crtIndex +')').css('zIndex', 2);
		this.fnPlay();

		//hover时暂停动画
		this.$ctn.hover(function() {
			me.fnStopPlay();
		}, function() {
			me.fnPlay();
		});

		if($.browser.msie && $.browser.version < 7) {
			this.$btns.hover(function() {
				$(this).addClass('hover');
			},function() {
				$(this).removeClass('hover');
			});
		}
	}
};
var player1 = new glume('_banners', '_focus');   
});

// 返回顶部
function goTopEx(){
        var obj=document.getElementById("goTopBtn");
        function getScrollTop(){
                return document.documentElement.scrollTop;
            }
        function setScrollTop(value){
                document.documentElement.scrollTop=value;
            }    
        window.onscroll=function(){getScrollTop()>0?obj.style.display="":obj.style.display="none";}
        obj.onclick=function(){
            var goTop=setInterval(scrollMove,10);
            function scrollMove(){
                    setScrollTop(getScrollTop()/1.1);
                    if(getScrollTop()<1)clearInterval(goTop);
                }
        }
    }
//news tab
function getID(news){
	return document.getElementById(news);
}
function HoverLi_news(n){
	for (var i=1 ;i<4;i++){
		if(i<4){
			getID("newsBox_"+i).className="none";
			if(n<4){
				getID("newsBox_"+n).className="newsdlTab dis";
			}
		}else{
			getID("newsBox_"+i).className="none";
			if(n>=4){
				getID("newsBox_"+n).className="newsdlTab dis";
			}
		}
		getID("newsTab_"+i).className="li-none";
		getID("newsTab_"+n).className="li-press";
	}
}

//slide banner index
$(function() {
	var sWidth = $("#focus").width(); //获取焦点图的宽度（显示面积）
	var len = $("#focus ul li").length; //获取焦点图个数
	var index = 0;
	var picTimer;
	
	//以下代码添加数字按钮和按钮后的半透明条，还有上一页、下一页两个按钮
	var btn = "<div class='btnBg'></div><div class='btn'>";
	for(var i=0; i < len; i++) {
		btn += "<span></span>";
	}
	btn += "</div><div class='preNext pre'></div><div class='preNext next'></div>";
	$("#focus").append(btn);
	$("#focus .btnBg").css("opacity",0.3);

	//为小按钮添加鼠标滑入事件，以显示相应的内容
	$("#focus .btn span").css("opacity",0.4).mouseenter(function() {
		index = $("#focus .btn span").index(this);
		showPics(index);
	}).eq(0).trigger("mouseenter");

	//上一页、下一页按钮透明度处理
	$("#focus .preNext").css("opacity",0.0).hover(function() {
		$(this).stop(true,false).animate({"opacity":"0.1"},300);
	},function() {
		$(this).stop(true,false).animate({"opacity":"0.0"},300);
	});

	//上一页按钮
	$("#focus .pre").click(function() {
		index -= 1;
		if(index == -1) {index = len - 1;}
		showPics(index);
	});

	//下一页按钮
	$("#focus .next").click(function() {
		index += 1;
		if(index == len) {index = 0;}
		showPics(index);
	});

	//本例为左右滚动，即所有li元素都是在同一排向左浮动，所以这里需要计算出外围ul元素的宽度
	$("#focus ul").css("width",sWidth * (len));
	
	//鼠标滑上焦点图时停止自动播放，滑出时开始自动播放
	$("#focus").hover(function() {
		clearInterval(picTimer);
	},function() {
		picTimer = setInterval(function() {
			showPics(index);
			index++;
			if(index == len) {index = 0;}
		},4000); //此4000代表自动播放的间隔，单位：毫秒
	}).trigger("mouseleave");
	
	//显示图片函数，根据接收的index值显示相应的内容
	function showPics(index) { //普通切换
		var nowLeft = -index*sWidth; //根据index值计算ul元素的left值
		$("#focus ul").stop(true,false).animate({"left":nowLeft},300); //通过animate()调整ul元素滚动到计算出的position
		//$("#focus .btn span").removeClass("on").eq(index).addClass("on"); //为当前的按钮切换到选中的效果
		$("#focus .btn span").stop(true,false).animate({"opacity":"0.4"},300).eq(index).stop(true,false).animate({"opacity":"1"},300); //为当前的按钮切换到选中的效果
	}
});
//loginPrompt hide
function loginPrompthide(){
	document.getElementById("loginPromptID").style.display="none";
}
//
//搜索
//
function drop_mouseover(pos){
 try{window.clearTimeout(timer);}catch(e){}
}
function drop_mouseout(pos){
 var posSel=document.getElementById(pos+"Sel").style.display;
 if(posSel=="block"){
  timer = setTimeout("drop_hide('"+pos+"')", 1000);
 }
}
function drop_hide(pos){
 document.getElementById(pos+"Sel").style.display="none";
}
function search_show(pos,searchType,href){
    document.getElementById(pos+"SearchType").value=searchType;
    document.getElementById(pos+"Sel").style.display="none";
    document.getElementById(pos+"Slected").innerHTML=href.innerHTML;
    document.getElementById(pos+'q').focus();
 try{window.clearTimeout(timer);}catch(e){}
 return false;
}
//
//返回顶部
//
function goTop(){
	$(window).scroll(function(e) {
    //若滚动条离顶部大于100元素
    if($(window).scrollTop()>100)
		$("#gotop").fadeIn(1000);//以1秒的间隔渐显id=gotop的元素
        else
        $("#gotop").fadeOut(1000);//以1秒的间隔渐隐id=gotop的元素
	});
};
$(function(){
	//点击回到顶部的元素
    $("#gotop").click(function(e) {
    	//以1秒的间隔返回顶部
    	$('body,html').animate({scrollTop:0},1000);
    });
	$("#gotop").mouseover(function(e) {
    	$(this).css("background","url(images/backtop.png) no-repeat 0px 0px");
	});
	$("#gotop").mouseout(function(e) {
		$(this).css("background","url(images/backtop.png) no-repeat -70px 0px");
	});
	goTop();//实现回到顶部元素的渐显与渐隐
});
////
/*任意位置浮动固定层 固定导航-在线客服-在线反馈等 */
/*Alon*/
/*陈河龙 , A.Designer QQ 408739876*/
/*2009-06-10修改：重新修改插件实现固定浮动层的方式，使用一个大固定层来定位
/*2009-07-16修改：修正IE6下无法固定在top上的问题
/*09-11-5修改：当自定义层的绝对位置时，加上top为空值时的判断
*/
/*调用：
1 无参数调用：默认浮动在右下角
$("#id").floatdiv();
2 内置固定位置浮动
//右下角
$("#id").floatdiv("rightbottom");
//左下角
$("#id").floatdiv("leftbottom");
//右下角
$("#id").floatdiv("rightbottom");
//左上角
$("#id").floatdiv("lefttop");
//右上角
$("#id").floatdiv("righttop");
//居中
$("#id").floatdiv("middle");
另外新添加了四个新的固定位置方法
middletop（居中置顶）、middlebottom（居中置低）、leftmiddle、rightmiddle
3 自定义位置浮动
$("#id").floatdiv({left:"10px",top:"10px"});
以上参数，设置浮动层在left 10个像素,top 10个像素的位置
*/
jQuery.fn.floatdiv=function(location){
		//判断浏览器版本
	var isIE6=false;
	var Sys = {};
    var ua = navigator.userAgent.toLowerCase();
    var s;
    (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] : 0;
	if(Sys.ie && Sys.ie=="6.0"){
		isIE6=true;
	}
	var windowWidth,windowHeight;//窗口的高和宽
	//取得窗口的高和宽
	if (self.innerHeight) {
		windowWidth=self.innerWidth;
		windowHeight=self.innerHeight;
	}else if (document.documentElement&&document.documentElement.clientHeight) {
		windowWidth=document.documentElement.clientWidth;
		windowHeight=document.documentElement.clientHeight;
	} else if (document.body) {
		windowWidth=document.body.clientWidth;
		windowHeight=document.body.clientHeight;
	}
	return this.each(function(){
		var loc;//层的绝对定位位置
		var wrap=$("<div></div>");
		var top=-1;
		if(location==undefined || location.constructor == String){
			switch(location){
				case("rightmiddletop")://自定义-1
					loc={right:"0px",top:"172px"};
					break;
				case("rightbottom")://右下角
					loc={right:"0px",bottom:"0px"};
					break;
				case("leftbottom")://左下角
					loc={left:"0px",bottom:"0px"};
					break;	
				case("lefttop")://左上角
					loc={left:"0px",top:"0px"};
					top=0;
					break;
				case("righttop")://右上角
					loc={right:"0px",top:"0px"};
					top=0;
					break;
				case("middletop")://居中置顶
					loc={left:windowWidth/2-$(this).width()/2+"px",top:"0px"};
					top=0;
					break;
				case("middlebottom")://居中置低
					loc={left:windowWidth/2-$(this).width()/2+"px",bottom:"0px"};
					break;
				case("leftmiddle")://左边居中
					loc={left:"0px",top:windowHeight/2-$(this).height()/2+"px"};
					top=windowHeight/2-$(this).height()/2;
					break;
				case("rightmiddle")://右边居中
					loc={right:"0px",top:windowHeight/2-$(this).height()/2+"px"};
					top=windowHeight/2-$(this).height()/2;
					break;
				case("middle")://居中
					var l=0;//居左
					var t=0;//居上
					l=windowWidth/2-$(this).width()/2;
					t=windowHeight/2-$(this).height()/2;
					top=t;
					loc={left:l+"px",top:t+"px"};
					break;
				default://默认为右下角
					location="rightbottom";
					loc={right:"50px",bottom:"50px"};
					break;
			}
		}else{
			loc=location;
			alert(loc.bottom);
			var str=loc.top;
			//09-11-5修改：加上top为空值时的判断
			if (typeof(str)!= ''){//括号值本为undefined
				str=str.replace("px","");
				top=str;
			}
		}
		/*fied ie6 css hack*/
		if(isIE6){
			if (top>=0)
			{
				wrap=$("<div style=\"top:expression(documentElement.scrollTop+"+top+");\"></div>");
			}else{
				wrap=$("<div style=\"top:expression(documentElement.scrollTop+documentElement.clientHeight-this.offsetHeight);\"></div>");
			}
		}
		$("body").append(wrap);
		
		wrap.css(loc).css({position:"fixed",
			z_index:"999"});
		if (isIE6)
		{
			
			wrap.css("position","absolute");
			//没有加这个的话，ie6使用表达式时就会发现跳动现象
			//至于为什么要加这个，还有为什么要加nothing.txt这个，偶也不知道，希望知道的同学可以告诉我
			$("body").css("background-attachment","fixed").css("background-image","url(n1othing.txt)");
		}
		//将要固定的层添加到固定层里
		$(this).appendTo(wrap);
	});
};
/////固定的在线反馈
$(function(){
	$(".onlineDivtx").floatdiv();
});
$(function(){
	$(".onlineDivQQ").floatdiv("rightmiddletop");
});
$(function(){
	$(".onlineDivQQ_mini").floatdiv("rightmiddletop");
});

//在线客服展开与隐藏
$(document).ready(function(){
	
	$('.onlineDivQQ').animate({height:'318px'}, 500 );
	$('.onlinebut').click(function(){
		$('.onlineDivQQ').show().animate({width:'1px'},500);
		$('.onlineDivQQ .onlinebox').show().animate({width:'1px'},500);
		$('.onlineDivQQ_mini').fadeIn(1500);
	})
	//将click换成mouseover即改成鼠标经过出现
	$('.onlineDivQQ_mini').click(function(){
		$(this).hide();
		$('.onlineDivQQ').show().animate({width:'216px'}, 500 );
		$('.onlineDivQQ .onlinebox').show().animate({width:'176px'},500);
	})
})
/*
QQ客服
*/
$(function(){
	var qqservice_text ="<li class='qq'><span>主客服一：</span><a target='_blank' href='http://wpa.qq.com/msgrd?v=3&uin=214485159&site=qq&menu=yes'><img border='0' src='http://wpa.qq.com/pa?p=2:214485159:51' alt='点击这里给我发消息' title='点击这里给我发消息'/></a></li>"+
	"<li class='qq'><span>主客服二：</span><a target='_blank' href='http://wpa.qq.com/msgrd?v=3&uin=214485159&site=qq&menu=yes'><img border='0' src='http://wpa.qq.com/pa?p=2:214485159:51' alt='点击这里给我发消息' title='点击这里给我发消息'/></a></li>"+
	"<li class='qq'><span>主客服三：</span><a target='_blank' href='http://wpa.qq.com/msgrd?v=3&uin=214485159&site=qq&menu=yes'><img border='0' src='http://wpa.qq.com/pa?p=2:214485159:51' alt='点击这里给我发消息' title='点击这里给我发消息'/></a></li>"+
	"<li class='qq'><span>主客服四：</span><a target='_blank' href='http://wpa.qq.com/msgrd?v=3&uin=214485159&site=qq&menu=yes'><img border='0' src='http://wpa.qq.com/pa?p=2:214485159:51' alt='点击这里给我发消息' title='点击这里给我发消息'/></a></li>"+
	"<div class='qq-time'><p class='qq-font1'>在线客服工作时间：</p><p>星期一至星期五</p><p>上午：8:30-12：:00</p><p>下午：2:30-5:30</p></div>"
	;
	$("#qqservice").append(qqservice_text);
});

/*课程中心*/




/*推荐课程*/
var ybvvjdt = function (id) {
	return "string" == typeof id ? document.getElementById(id) : id;
};

var Class = {
  create: function() {
	return function() {
	  this.initialize.apply(this, arguments);
	}
  }
}

Object.extend = function(destination, source) {
	for (var property in source) {
		destination[property] = source[property];
	}
	return destination;
}

var TransformView = Class.create();
TransformView.prototype = {
 
  initialize: function(container, slider, parameter, count, options) {
	if(parameter <= 0 || count <= 0) return;
	var oContainer = ybvvjdt(container), oSlider = ybvvjdt(slider), oThis = this;

	this.Index = 0;
	
	this._timer = null;
	this._slider = oSlider;
	this._parameter = parameter;
	this._count = count || 0;
	this._target = 0;
	
	this.SetOptions(options);
	
	this.Up = !!this.options.Up;
	this.Step = Math.abs(this.options.Step);
	this.Time = Math.abs(this.options.Time);
	this.Auto = !!this.options.Auto;
	this.Pause = Math.abs(this.options.Pause);
	this.onStart = this.options.onStart;
	this.onFinish = this.options.onFinish;
	
	oContainer.style.overflow = "hidden";
	oContainer.style.position = "relative";
	
	oSlider.style.position = "absolute";
	oSlider.style.top = oSlider.style.left = 0;
  },
  SetOptions: function(options) {
	this.options = {
		Up:			true,
		Step:		5,
		Time:		10,
		Auto:		true,
		Pause:		200,
		onStart:	function(){},
		onFinish:	function(){}
	};
	Object.extend(this.options, options || {});
  },
  Start: function() {
	if(this.Index < 0){
		this.Index = this._count - 1;
	} else if (this.Index >= this._count){ this.Index = 0; }
	
	this._target = -1 * this._parameter * this.Index;
	this.onStart();
	this.Move();
  },
  Move: function() {
	clearTimeout(this._timer);
	var oThis = this, style = this.Up ? "top" : "left", iNow = parseInt(this._slider.style[style]) || 0, iStep = this.GetStep(this._target, iNow);
	
	if (iStep != 0) {
		this._slider.style[style] = (iNow + iStep) + "px";
		this._timer = setTimeout(function(){ oThis.Move(); }, this.Time);
	} else {
		this._slider.style[style] = this._target + "px";
		this.onFinish();
		if (this.Auto) { this._timer = setTimeout(function(){ oThis.Index++; oThis.Start(); }, this.Pause); }
	}
  },
  GetStep: function(iTarget, iNow) {
	var iStep = (iTarget - iNow) / this.Step;
	if (iStep == 0) return 0;
	if (Math.abs(iStep) < 1) return (iStep > 0 ? 1 : -1);
	return iStep;
  },
  Stop: function(iTarget, iNow) {
	clearTimeout(this._timer);
	this._slider.style[this.Up ? "top" : "left"] = this._target + "px";
  }
};


	function Each(list, fun){
		for (var i = 0, len = list.length; i < len; i++) { fun(list[i], i); }
	};



	
	
	function mytv(aa,bb,cc,dd,ee,ff,gg,hh,ii,jj){
var objs = ybvvjdt(aa).getElementsByTagName("li");
var tv = new TransformView(bb,cc,dd,ee, {
onStart : function(){ Each(objs, function(o, i){ o.className = tv.Index == i ? "on" : ""; }) }//°´Å¥ÑùÊ½
});



Each(objs, function(o, i){
function autoplay(){
//tv.Index = i;				
tv.Up = ff;
tv.Pause = gg;
tv.Step = hh;
	if(ii==true){
		tv.Auto=true;
		tv.Start();}
		else{
		tv.Auto = false;
		tv.Start();
		
			}	
	}
	
autoplay();	
if(jj=="onmouseover"){	
o.onmouseover = function(){	
o.className = "on";
tv.Index = i;
ii=false;
autoplay();

}
o.onmouseout = function(){
o.className = "";
ii=true;
autoplay();
}
}
if(jj=="onclick"){	
o.onclick = function(){
o.className = "on";
tv.Index = i;
autoplay();
}
}

})
}
/*学员登录的tab*/
//tab effects
var TabbedContent = {
	init: function() {	
		$(".tab_item").click(function() {
		
			var background = $(this).parent().find(".moving_bg");
			
			$(background).stop().animate({
				left: $(this).position()['left']
			}, {
				duration: 300
			});
			
			TabbedContent.slideContent($(this));
			
		});
	},
	
	slideContent: function(obj) {
		
		var margin = $(obj).parent().parent().find(".slide_content").width();
		margin = margin * ($(obj).prevAll().size() - 1);
		margin = margin * -1;
		
		$(obj).parent().parent().find(".tabslider").stop().animate({
			marginLeft: margin + "px"
		}, {
			duration: 300
		});
	}
}

$(document).ready(function() {
	TabbedContent.init();
});

//table表格隔行换色
function senfe(o,a,b,c,d){
var t=document.getElementById(o).getElementsByTagName("tr");
for(var i=0;i<t.length;i++){
t[i].style.backgroundColor=(t[i].sectionRowIndex%2==0)?a:b;
t[i].onclick=function(){
   if(this.x!="1"){
    this.x="1";//本来打算直接用背景色判断，FF获取到的背景是RGB值，不好判断
    this.style.backgroundColor=d;
   }else{
    this.x="0";
    this.style.backgroundColor=(this.sectionRowIndex%2==0)?a:b;
   }
}
t[i].onmouseover=function(){
   if(this.x!="1")this.style.backgroundColor=c;
}
t[i].onmouseout=function(){
   if(this.x!="1")this.style.backgroundColor=(this.sectionRowIndex%2==0)?a:b;
}
}
}
//table表格隔行换色完

//导航栏下拉二级菜单
(function($){
    $.fn.capacityFixed = function(options) {
        var opts = $.extend({},$.fn.capacityFixed.deflunt,options);
        var FixedFun = function(element) {
            var top = opts.top;
            element.css({
                "top":top
            });
          
            element.find(".close-ico").click(function(event){
                element.remove();
                event.preventDefault();
            })
        };
        return $(this).each(function() {
            FixedFun($(this));
        });
    };
    $.fn.capacityFixed.deflunt={
		right :0,//相对于页面宽度的右边定位
        bottom:0
	};
})(jQuery);

/***********************************************************/
/*                    tinyTips Plugin                      */
/*                      Version: 1.1                       */
/*                      Mike Merritt                       */
/*                 Updated: Mar 2nd, 2010                  */
/***********************************************************/

(function($){  
	$.fn.tinyTips = function (tipColor, supCont) {
		
		if (tipColor === 'null') {
			tipColor = 'light';
		} 
		
		var tipName = tipColor + 'Tip';
		
		/* User settings
		**********************************/
		
		// Enter the markup for your tooltips here. The wrapping div must have a class of tinyTip and 
		// it must have a div with the class "content" somewhere inside of it.
		var tipFrame = '<div class="' + tipName + '"><div class="content"></div><div class="bottom">&nbsp;</div></div>';
		
		// Speed of the animations in milliseconds - 1000 = 1 second.
		var animSpeed = 300;
		
		/***************************************************************************************************/
		/* End of user settings - Do not edit below this line unless you are trying to edit functionality. */
		/***************************************************************************************************/
		
		// Global tinyTip variables;
		var tinyTip;
		var tText;
		
		// When we hover over the element that we want the tooltip applied to
		$(this).hover(function() {
		
			// Inject the markup for the tooltip into the page and
			// set the tooltip global to the current markup and then hide it.
			$('body').append(tipFrame);
			var divTip = 'div.'+tipName;
			tinyTip = $(divTip);
			tinyTip.hide();
			
			// Grab the content for the tooltip from the title attribute (or the supplied content) and
			// inject it into the markup for the current tooltip. NOTE: title attribute is used unless
			// other content is supplied instead.
			if (supCont === 'title') {
				var tipCont = $(this).attr('title');
			} else if (supCont !== 'title') {
				var tipCont = supCont;
			}
			$(divTip + ' .content').html(tipCont);
			tText = $(this).attr('title');
			$(this).attr('title', '');
			
			// Offsets so that the tooltip is centered over the element it is being applied to but
			// raise it up above the element so it isn't covering it.
			var yOffset = tinyTip.height() + 2;
			var xOffset = (tinyTip.width() / 2) - ($(this).width() / 2);
			
			// Grab the coordinates for the element with the tooltip and make a new copy
			// so that we can keep the original un-touched.
			var pos = $(this).offset();
			var nPos = pos;
			
			// Add the offsets to the tooltip position
			nPos.top = pos.top - yOffset;
			nPos.left = pos.left - xOffset;
			
			// Make sure that the tooltip has absolute positioning and a high z-index, 
			// then place it at the correct spot and fade it in.
			tinyTip.css('position', 'absolute').css('z-index', '1000');
			tinyTip.css(nPos).fadeIn(animSpeed);
			
		}, function() {
			
			$(this).attr('title', tText);
		
			// Fade the tooltip out once the mouse moves away and then remove it from the DOM.
			tinyTip.fadeOut(animSpeed, function() {
				$(this).remove();
			});
			
		});
		
	}

})(jQuery);


// 首页滚动新闻条
if(document.getElementById("jsfoot01")){
	var scrollup = new ScrollText("jsfoot01");
	scrollup.LineHeight = 37;        //单排文字滚动的高度
	scrollup.Amount = 1;            //注意:子模块(LineHeight)一定要能整除Amount.
	scrollup.Delay = 20;           //延时
	scrollup.Start();             //文字自动滚动
	scrollup.Direction = "down"; //文字向下滚动
}

