


//(function (n) { l = g = 1; k = n + 1; for (i = k; i <= 2 * n; i++) { l *= i; g *= k; k--; } return l / g / 2 })();

//for (var p = 0; p < 13; p++) {
// //   console.log(p);
// //   console.log(catalan(p));
//    console.log(b(p));
//    //console.log(a(i));
//}


//function b(n){n==5?m=21:(n==1?m=0.5:n==2?m=1:(n==3?m=2.5:m=7));return m;}

function b(n){l=g=1;k=n+1;for(i=k;i<=2*n;i++){l*=i;g*=(k--)}return (l/g)/2}
var d = [];
d.push(b(11));
console.log(b(11)+1);
console.log(d);