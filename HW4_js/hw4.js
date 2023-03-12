function counter() {
    let sum = 0;
    
    function add(number) {
      sum += number;
      return sum;
    }
    
    return add;
  }

  