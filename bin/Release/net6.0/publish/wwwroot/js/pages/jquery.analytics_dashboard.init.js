/**
 * Theme: Dastone - Responsive Bootstrap 5 Admin Dashboard
 * Author: Mannatthemes
 * Analytics Dashboard Js
 */



var options = {
  chart: {
      height: 320,
      type: 'area',
      stacked: true,
      toolbar: {
        show: false,
        autoSelected: 'zoom'
      },
  },
  colors: ['#2a77f4', '#a5c2f1'],
  dataLabels: {
      enabled: false
  },
  stroke: {
      curve: 'smooth',
      width: [1.5, 1.5],
      dashArray: [0, 4],
      lineCap: 'round',
  },
  grid: {
    padding: {
      left: 0,
      right: 0
    },
    strokeDashArray: 3,
  },
  markers: {
    size: 0,
    hover: {
      size: 0
    }
  },
  series: [{
      name: 'New Visits',
      data: [0,60,20,90,45,110,55,130,44,110,75,120]
  }, {
      name: 'Unique Visits',
      data: [0,45,10,75,35,94,40,115,30,105,65,110]
  }],

  xaxis: {
      type: 'month',
      categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
      axisBorder: {
        show: true,
      },  
      axisTicks: {
        show: true,
      },                  
  },
  fill: {
    type: "gradient",
    gradient: {
      shadeIntensity: 1,
      opacityFrom: 0.4,
      opacityTo: 0.3,
      stops: [0, 90, 100]
    }
  },
  
  tooltip: {
      x: {
          format: 'dd/MM/yy HH:mm'
      },
  },
  legend: {
    position: 'top',
    horizontalAlign: 'right'
  },
}

var chart = new ApexCharts(
  document.querySelector("#ana_dash_1"),
  options
);

chart.render();

// Spark


// var options = {
//   series: [76],
//   chart: {
//   type: 'radialBar',
//   offsetY: -20,
//   sparkline: {
//     enabled: true
//   }
// },
// plotOptions: {
//   radialBar: {
//     startAngle: -90,
//     endAngle: 90,  
//     hollow: {
//       size: '75%',
//       position: 'front',
//   },  
//     track: {
//       background: ["rgba(42, 118, 244, .18)"],
//       strokeWidth: '80%',
//       opacity: 0.5,
//       margin: 5,
//     },
//     dataLabels: {
//       name: {
//         show: false
//       },
//       value: {
//         offsetY: -2,
//         fontSize: '20px'
//       }
//     }
//   }
// },
// stroke: {
//   lineCap: 'butt'
// },
// colors: ["#2a76f4"],
// grid: {
//   padding: {
//     top: -10
//   }
// },

// labels: ['Average Results'],
// };

// var chart = new ApexCharts(document.querySelector("#ana_1"), options);
// chart.render();



//Device-widget

 
var options = {
  chart: {
      height: 270,
      type: 'donut',
  }, 
  plotOptions: {
    pie: {
      donut: {
        size: '85%'
      }
    }
  },
  dataLabels: {
    enabled: false,
  },

  stroke: {
    show: true,
    width: 2,
    colors: ['transparent']
  },
 
  series: [50, 25, 25,],
  legend: {
    show: true,
    position: 'bottom',
    horizontalAlign: 'center',
    verticalAlign: 'middle',
    floating: false,
    fontSize: '13px',
    offsetX: 0,
    offsetY: 0,
  },
  labels: [ "Mobile","Tablet", "Desktop" ],
  colors: ["#2a76f4","rgba(42, 118, 244, .5)","rgba(42, 118, 244, .18)"],
 
  responsive: [{
      breakpoint: 600,
      options: {
        plotOptions: {
            donut: {
              customScale: 0.2
            }
          },        
          chart: {
              height: 240
          },
          legend: {
              show: false
          },
      }
  }],
  tooltip: {
    y: {
        formatter: function (val) {
            return   val + " %"
        }
    }
  }
  
}

var chart = new ApexCharts(
  document.querySelector("#ana_device"),
  options
);

chart.render();




var colors = ['#98e7df', '#b8c4d0', '#bec7fa', '#ffe2a3', '#92e6f0'];
var options = {
  series: [{
  name: 'Inflation',
  data: [ 4.0, 10.1, 6.0, 8.0, 9.1]
}],
  chart: {
  height: 355,
  type: 'bar',
  toolbar:{
    show:false
  },
},
plotOptions: {
  bar: {
      dataLabels: {
          position: 'top', // top, center, bottom              
      },
      columnWidth: '20',
      distributed: true,
  },

},
dataLabels: {
  enabled: true,
  formatter: function (val) {
    return val + "%";
  },
  offsetY: -20,
  style: {
    fontSize: '12px',
    colors: ["#000"]
  }
},
colors: colors,
xaxis: {
  categories: ["Email", "Referral", "Organic", "Direct", "Campaign",],
  position: 'top',
  axisBorder: {
    show: false
  },
  axisTicks: {
    show: false
  },
  crosshairs: {
    fill: {
      type: 'gradient',
      gradient: {
        colorFrom: '#D8E3F0',
        colorTo: '#BED1E6',
        stops: [0, 100],
        opacityFrom: 0.4,
        opacityTo: 0.5,
      }
    }
  },
  tooltip: {
    enabled: true,
  },
},

grid: {
  padding: {
    left: 0,
    right: 0
  },
  strokeDashArray: 3,
},
yaxis: {
  axisBorder: {
    show: false
  },
  axisTicks: {
    show: false,
  },
  labels: {
    show: false,
    formatter: function (val) {
      return val + "%";
    }
  }

},
};

var chart = new ApexCharts(document.querySelector("#barchart"), options);
chart.render();