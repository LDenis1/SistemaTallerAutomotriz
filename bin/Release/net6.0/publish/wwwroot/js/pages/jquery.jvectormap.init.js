/**
 * Theme: Dastone - Responsive Bootstrap 5 Admin Dashboard
 * Author: Mannatthemes
 * Jvectormap Js
 */

 
!function($) {
  "use strict";

  var VectorMap = function() {};

  VectorMap.prototype.init = function() {
      //various examples
      $('#world-map-markers').vectorMap({
    map : 'world_mill_en',
    scaleColors : ['#4d79f6', '#4d79f6'],
    normalizeFunction : 'polynomial',
    hoverOpacity : 0.7,
    hoverColor : false,
    regionStyle : {
      initial : {
        fill : '#e2e3e8'
      }
    },
     markerStyle: {
              initial: {
                  r: 4,
                  'fill': '#8a8da0',
                  'fill-opacity': 1,
                  'stroke': '#fff',
                  'stroke-width' : 1,
                  'stroke-opacity': 0.1
              },

              hover: {
                  'stroke': '#fff',
                  'fill-opacity': 1,
                  'stroke-width': 1.5
              }
          },
    backgroundColor : 'transparent',
    markers : [ {
      latLng : [-8.51, 179.21],
      name : 'Tuvalu'
    }, {
      latLng : [3.2, 73.22],
      name : 'Maldives'
    }, {
      latLng : [35.88, 14.5],
      name : 'Malta'
    }, {
      latLng : [12.05, -61.75],
      name : 'Grenada'
    }, {
      latLng : [7.35, 134.46],
      name : 'Palau'
    }, {
      latLng : [42.5, 1.51],
      name : 'Andorra'
    },{
      latLng : [26.02, 50.55],
      name : 'Bahrain'
    },]
  });

      $('#usa').vectorMap({map: 'us_aea_en',backgroundColor: 'transparent',
                regionStyle: {
                  initial: {
                    fill: '#e2e3e8'
                  }
        }});
  $('#canada').vectorMap({map : 'ca_lcc',backgroundColor : 'transparent',
        regionStyle : {
          initial : {
            fill : '#e2e3e8'
          }
        }});
      $('#uk').vectorMap({map: 'uk_mill_en',backgroundColor: 'transparent',
        regionStyle: {
          initial: {
            fill: '#e2e3e8'
          }
        }});
      $('#chicago').vectorMap({map: 'us-il-chicago_mill_en',backgroundColor: 'transparent',
        regionStyle: {
          initial: {
            fill: '#e2e3e8'
          }
        }});

},


  //init
  $.VectorMap = new VectorMap, $.VectorMap.Constructor = VectorMap
}(window.jQuery),

//initializing 
function($) {
  "use strict";
  $.VectorMap.init()
}(window.jQuery);