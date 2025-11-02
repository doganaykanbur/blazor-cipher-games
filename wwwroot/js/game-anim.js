window.resetAnim = function() {
  // örnek: geri al renkleri
  gsap.to("#feedback", {duration:0.2, backgroundColor: "transparent", color: "#222"});
}

window.successAnim = function() {
  gsap.fromTo("#feedback", {scale:0.95, backgroundColor:"#eaffea", color:"#0a7a0a"}, {duration:0.6, scale:1.03, boxShadow:"0 8px 30px rgba(0,150,0,0.2)", ease:"elastic.out(1,0.6)"});
  // kutucuk yeşile dönsün
  gsap.to("body", {duration:0.6, backgroundColor:"#f2fff4"});
  // küçük konfeti efekti (basit)
  for(let i=0;i<16;i++){
    const d=document.createElement("div");
    d.style.position="fixed";
    d.style.left=(50+ (Math.random()-0.5)*40) + "%";
    d.style.top=(40+ (Math.random()-0.5)*20) + "%";
    d.style.width="8px";
    d.style.height="8px";
    d.style.background = ["#2ecc71","#27ae60","#16a085","#1abc9c"][Math.floor(Math.random()*4)];
    d.style.borderRadius="2px";
    d.style.opacity=0.9;
    document.body.appendChild(d);
    gsap.to(d,{y:200+Math.random()*200, x:(Math.random()-0.5)*200, rotation:360, duration:1.6, ease:"power4.out", onComplete:()=>d.remove()});
  }
}

window.failAnim = function() {
  gsap.fromTo("#feedback", {scale:0.95, backgroundColor:"#ffecec", color:"#a10000"}, {duration:0.5, scale:1.02, boxShadow:"0 8px 30px rgba(200,0,0,0.15)", ease:"back.out(2)"});
  gsap.to("body", {duration:0.6, backgroundColor:"#fff6f6"});
}
