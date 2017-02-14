require('./game.js');
require('./random.js')
var approvals = require('approvals');

describe("The test environment", function() {
  it("should have access to the game", function() {
    expect(Game).toBeDefined();
    expect(Main).toBeDefined();
  });
});

describe("Golden master tests", function() {
  function verify(data){
    approvals.verify(__dirname, 'golden master', data,{normalizeLineEndingsTo: "\r\n"});
  }

  var output = "";
  var oldOut;

  beforeEach(function(){
    oldOut = console.log;
    console.log = function(text){
      output += text + "\n";
    }
  });

  afterEach(function(){
    output = "";
    console.log = oldOut;
  });

  it("Should keep the same output as before", function(){
    var seed = 1337;
  	var rng = Random(seed);
  	

    for(var i = 0; i < 100; i++){
      console.log("Playing game "+i);
      RunGame(rng);
    }
    	
  	verify(output);
  });
});
