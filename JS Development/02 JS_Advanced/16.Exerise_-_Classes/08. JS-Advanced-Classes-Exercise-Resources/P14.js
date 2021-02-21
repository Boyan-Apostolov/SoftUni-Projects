class StringBuilder {
  constructor(string) {
    if (string !== undefined) {  //ok
      StringBuilder._vrfyParam(string);
      this._stringArray = Array.from(string); // ok
    } else {
      this._stringArray = []; //ok
    }
  }

  append(string) {
    StringBuilder._vrfyParam(string); // ok
    for (let i = 0; i < string.length; i++) {
      this._stringArray.push(string[i]);
    }
  }

  prepend(string) {
    StringBuilder._vrfyParam(string); //ok
    for (let i = string.length - 1; i >= 0; i--) {
      this._stringArray.unshift(string[i]);
    }
  }

  insertAt(string, startIndex) {
    StringBuilder._vrfyParam(string);
    this._stringArray.splice(startIndex, 0, ...string);
  }

  remove(startIndex, length) {
    this._stringArray.splice(startIndex, length);
  }

  static _vrfyParam(param) {
    if (typeof param !== 'string') throw new TypeError('Argument must be а string');
  }

  toString() {
    return this._stringArray.join('');
  }
}

const { assert } = require('chai')

describe('String Builder Tests', () => {
  it('Constructor', () => {
    let stringBuilder = new StringBuilder();
    assert.isTrue(stringBuilder._stringArray.length == 0)

    let stringBuilder2 = new StringBuilder('t');
    assert.isTrue(stringBuilder2._stringArray.length == 1)
    stringBuilder2.append('he')
    assert.isTrue(stringBuilder2._stringArray.length == 3)

    assert.throws(() => {
      let stringBuilder3 = new stringBuilder(undefined);
    }, TypeError)
    assert.throws(() => {
      let stringBuilder3 = new stringBuilder(0);
    }, TypeError)
    assert.throws(() => {
      let stringBuilder3 = new stringBuilder(null);
    }, TypeError)
    assert.throws(() => {
      let stringBuilder3 = new stringBuilder(-1);
    }, TypeError)
  })

  it('append', () => {
    let stringBuilder = new StringBuilder();

    stringBuilder.append('a')
    stringBuilder.append('b')
    stringBuilder.append('c')

    assert.isTrue(stringBuilder._stringArray[1] == 'b')
    assert.isTrue(stringBuilder._stringArray[2] == 'c')
    assert.isTrue(stringBuilder._stringArray[0] == 'a')

    assert.throws(() => { stringBuilder.append(1) }, TypeError)
    assert.throws(() => { stringBuilder.append(null) }, TypeError)
    assert.throws(() => { stringBuilder.append(undefined) }, TypeError)

    stringBuilder._stringArray = [];
    stringBuilder.append('hello')
    assert.isTrue(stringBuilder._stringArray[1] == 'e')
  })

  it('prepend', () => {
    let stringBuilder = new StringBuilder();

    stringBuilder.prepend('a')
    stringBuilder.prepend('b')
    stringBuilder.prepend('c')

    assert.isTrue(stringBuilder._stringArray[0] == 'c')
    assert.isTrue(stringBuilder._stringArray[1] == 'b')
    assert.isTrue(stringBuilder._stringArray[2] == 'a')

    assert.throws(() => { stringBuilder.prepend(1) }, TypeError)
    assert.throws(() => { stringBuilder.prepend(null) }, TypeError)
    assert.throws(() => { stringBuilder.prepend(undefined) }, TypeError)

    stringBuilder._stringArray = [];
    stringBuilder.prepend('hello')
    stringBuilder.prepend('a')
    assert.isTrue(stringBuilder._stringArray[0] == 'a')
  })

  it('insert at', () => {
    let stringBuilder = new StringBuilder();

    stringBuilder.insertAt('a', 0)
    stringBuilder.insertAt('b', 1)
    stringBuilder.insertAt('c', 2)

    assert.isTrue(stringBuilder._stringArray[0] == 'a')

    assert.throws(() => { stringBuilder.insertAt(1, 1) }, Error)
    assert.throws(() => { stringBuilder.insertAt(null, 1) }, Error)
    assert.throws(() => { stringBuilder.insertAt(undefined, 1) }, Error)

    assert.throws(() => { stringBuilder.insertAt(1, '1') }, Error)
    assert.throws(() => { stringBuilder.insertAt(1, null) }, Error)
    assert.throws(() => { stringBuilder.insertAt(1, undefined) }, Error)
  })

  it('_vrfyParam', () => {
    let stringBuilder = new StringBuilder();

    stringBuilder.append('a')
    stringBuilder.append('b')
    stringBuilder.append('c')
    stringBuilder.append('d')

    assert.isTrue(stringBuilder._stringArray[1] == 'b')
    assert.isTrue(stringBuilder._stringArray[0] == 'a')
    assert.isTrue(stringBuilder._stringArray[2] == 'c')
    assert.isTrue(stringBuilder._stringArray[3] == 'd')

    assert.throws(() => { stringBuilder.append(1) }, TypeError)
    assert.throws(() => { stringBuilder.append(null) }, TypeError)
    assert.throws(() => { stringBuilder.append(undefined) }, TypeError)
  })

  it('toString', () => {
    let stringBuilder = new StringBuilder();

    stringBuilder.insertAt('a', 0)
    stringBuilder.insertAt('b', 1)
    stringBuilder.insertAt('c', 2)

    assert.isTrue(stringBuilder.toString() == 'abc')

    stringBuilder.remove(0, 1)

    assert.isTrue(stringBuilder.toString() == 'bc')

    stringBuilder.remove(0, 99)

    assert.isTrue(stringBuilder.toString() == '')

  })

  it('remove at', () => {
    let stringBuilder = new StringBuilder();

    stringBuilder.append('a')
    stringBuilder.append('b')
    stringBuilder.append('c')
    stringBuilder.append('d')

    assert.doesNotThrow(() => { stringBuilder.remove(1, 1) }) //works

    stringBuilder.remove(1, 1);

    assert.isTrue(stringBuilder._stringArray[1] == 'd')

    //with wrong inputs
    assert.doesNotThrow(() => { stringBuilder.remove(1, 'hello') })
    stringBuilder.remove(1, 'hello')

    assert.doesNotThrow(() => {
      stringBuilder.remove('hello', 'hello')
      stringBuilder.remove('hello', 1)
      stringBuilder.remove(null, null)
      stringBuilder.remove(undefined, null)
      stringBuilder.remove(null, undefined)
      stringBuilder.remove(undefined, undefined)
      stringBuilder.remove()
    })

    assert.isTrue(stringBuilder._stringArray.length == 1)
  })
})