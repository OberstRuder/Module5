function counter() {
    let sum = 0;
    
    function add(number) {
      sum += number;
      return sum;
    }
    
    return add;
}

  function getUpdatedArr() {
    if (!getUpdatedArr.arr) {
      getUpdatedArr.arr = [];
    }
  
    if (arguments.length === 0) {
      getUpdatedArr.arr = [];
    } else {
      for (let i = 0; i < arguments.length; i++) {
        getUpdatedArr.arr.push(arguments[i]);
      }
    }
  
    return getUpdatedArr.arr;
  }