exports = typeof window !== "undefined" && window !== null ? window : global;

exports.Random = function(seed) {
	return function() {
	    var x = Math.sin(seed++) * 10000;
	    return x - Math.floor(x);
	};
};