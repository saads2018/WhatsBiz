/*! For license information please see wppconnect-wa.js.LICENSE.txt */
!(function (e, t) {
    'object' == typeof exports && 'object' == typeof module
        ? (module.exports = t())
        : 'function' == typeof define && define.amd
            ? define([], t)
            : 'object' == typeof exports
                ? (exports.WAPIAPI = t())
                : (e.WAPIAPI = t())
})(self, () =>
    (() => {
        var __webpack_modules__ = {
            6251: (e, t) => {
                'use strict'
                    ; (t.byteLength = function (e) {
                        var t = u(e),
                            r = t[0],
                            n = t[1]
                        return (3 * (r + n)) / 4 - n
                    }),
                        (t.toByteArray = function (e) {
                            var t,
                                r,
                                o = u(e),
                                s = o[0],
                                a = o[1],
                                c = new i(
                                    (function (e, t, r) {
                                        return (3 * (t + r)) / 4 - r
                                    })(0, s, a)
                                ),
                                l = 0,
                                d = a > 0 ? s - 4 : s
                            for (r = 0; r < d; r += 4)
                                (t =
                                    (n[e.charCodeAt(r)] << 18) |
                                    (n[e.charCodeAt(r + 1)] << 12) |
                                    (n[e.charCodeAt(r + 2)] << 6) |
                                    n[e.charCodeAt(r + 3)]),
                                    (c[l++] = (t >> 16) & 255),
                                    (c[l++] = (t >> 8) & 255),
                                    (c[l++] = 255 & t)
                            return (
                                2 === a && ((t = (n[e.charCodeAt(r)] << 2) | (n[e.charCodeAt(r + 1)] >> 4)), (c[l++] = 255 & t)),
                                1 === a &&
                                ((t = (n[e.charCodeAt(r)] << 10) | (n[e.charCodeAt(r + 1)] << 4) | (n[e.charCodeAt(r + 2)] >> 2)),
                                    (c[l++] = (t >> 8) & 255),
                                    (c[l++] = 255 & t)),
                                c
                            )
                        }),
                        (t.fromByteArray = function (e) {
                            for (var t, n = e.length, i = n % 3, o = [], s = 16383, a = 0, u = n - i; a < u; a += s)
                                o.push(c(e, a, a + s > u ? u : a + s))
                            return (
                                1 === i
                                    ? ((t = e[n - 1]), o.push(r[t >> 2] + r[(t << 4) & 63] + '=='))
                                    : 2 === i &&
                                    ((t = (e[n - 2] << 8) + e[n - 1]), o.push(r[t >> 10] + r[(t >> 4) & 63] + r[(t << 2) & 63] + '=')),
                                o.join('')
                            )
                        })
                for (
                    var r = [],
                    n = [],
                    i = 'undefined' != typeof Uint8Array ? Uint8Array : Array,
                    o = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/',
                    s = 0,
                    a = o.length;
                    s < a;
                    ++s
                )
                    (r[s] = o[s]), (n[o.charCodeAt(s)] = s)
                function u(e) {
                    var t = e.length
                    if (t % 4 > 0) throw new Error('Invalid string. Length must be a multiple of 4')
                    var r = e.indexOf('=')
                    return -1 === r && (r = t), [r, r === t ? 0 : 4 - (r % 4)]
                }
                function c(e, t, n) {
                    for (var i, o, s = [], a = t; a < n; a += 3)
                        (i = ((e[a] << 16) & 16711680) + ((e[a + 1] << 8) & 65280) + (255 & e[a + 2])),
                            s.push(r[((o = i) >> 18) & 63] + r[(o >> 12) & 63] + r[(o >> 6) & 63] + r[63 & o])
                    return s.join('')
                }
                ; (n['-'.charCodeAt(0)] = 62), (n['_'.charCodeAt(0)] = 63)
            },
            692: (e, t, r) => {
                'use strict'
                const n = r(6251),
                    i = r(7467),
                    o =
                        'function' == typeof Symbol && 'function' == typeof Symbol.for
                            ? Symbol.for('nodejs.util.inspect.custom')
                            : null
                    ; (t.lW = u), (t.h2 = 50)
                const s = 2147483647
                function a(e) {
                    if (e > s) throw new RangeError('The value "' + e + '" is invalid for option "size"')
                    const t = new Uint8Array(e)
                    return Object.setPrototypeOf(t, u.prototype), t
                }
                function u(e, t, r) {
                    if ('number' == typeof e) {
                        if ('string' == typeof t)
                            throw new TypeError('The "string" argument must be of type string. Received type number')
                        return d(e)
                    }
                    return c(e, t, r)
                }
                function c(e, t, r) {
                    if ('string' == typeof e)
                        return (function (e, t) {
                            if ((('string' == typeof t && '' !== t) || (t = 'utf8'), !u.isEncoding(t)))
                                throw new TypeError('Unknown encoding: ' + t)
                            const r = 0 | g(e, t)
                            let n = a(r)
                            const i = n.write(e, t)
                            return i !== r && (n = n.slice(0, i)), n
                        })(e, t)
                    if (ArrayBuffer.isView(e))
                        return (function (e) {
                            if (Q(e, Uint8Array)) {
                                const t = new Uint8Array(e)
                                return p(t.buffer, t.byteOffset, t.byteLength)
                            }
                            return f(e)
                        })(e)
                    if (null == e)
                        throw new TypeError(
                            'The first argument must be one of type string, Buffer, ArrayBuffer, Array, or Array-like Object. Received type ' +
                            typeof e
                        )
                    if (Q(e, ArrayBuffer) || (e && Q(e.buffer, ArrayBuffer))) return p(e, t, r)
                    if (
                        'undefined' != typeof SharedArrayBuffer &&
                        (Q(e, SharedArrayBuffer) || (e && Q(e.buffer, SharedArrayBuffer)))
                    )
                        return p(e, t, r)
                    if ('number' == typeof e)
                        throw new TypeError('The "value" argument must not be of type number. Received type number')
                    const n = e.valueOf && e.valueOf()
                    if (null != n && n !== e) return u.from(n, t, r)
                    const i = (function (e) {
                        if (u.isBuffer(e)) {
                            const t = 0 | m(e.length),
                                r = a(t)
                            return 0 === r.length || e.copy(r, 0, 0, t), r
                        }
                        return void 0 !== e.length
                            ? 'number' != typeof e.length || Y(e.length)
                                ? a(0)
                                : f(e)
                            : 'Buffer' === e.type && Array.isArray(e.data)
                                ? f(e.data)
                                : void 0
                    })(e)
                    if (i) return i
                    if (
                        'undefined' != typeof Symbol &&
                        null != Symbol.toPrimitive &&
                        'function' == typeof e[Symbol.toPrimitive]
                    )
                        return u.from(e[Symbol.toPrimitive]('string'), t, r)
                    throw new TypeError(
                        'The first argument must be one of type string, Buffer, ArrayBuffer, Array, or Array-like Object. Received type ' +
                        typeof e
                    )
                }
                function l(e) {
                    if ('number' != typeof e) throw new TypeError('"size" argument must be of type number')
                    if (e < 0) throw new RangeError('The value "' + e + '" is invalid for option "size"')
                }
                function d(e) {
                    return l(e), a(e < 0 ? 0 : 0 | m(e))
                }
                function f(e) {
                    const t = e.length < 0 ? 0 : 0 | m(e.length),
                        r = a(t)
                    for (let n = 0; n < t; n += 1) r[n] = 255 & e[n]
                    return r
                }
                function p(e, t, r) {
                    if (t < 0 || e.byteLength < t) throw new RangeError('"offset" is outside of buffer bounds')
                    if (e.byteLength < t + (r || 0)) throw new RangeError('"length" is outside of buffer bounds')
                    let n
                    return (
                        (n =
                            void 0 === t && void 0 === r
                                ? new Uint8Array(e)
                                : void 0 === r
                                    ? new Uint8Array(e, t)
                                    : new Uint8Array(e, t, r)),
                        Object.setPrototypeOf(n, u.prototype),
                        n
                    )
                }
                function m(e) {
                    if (e >= s)
                        throw new RangeError(
                            'Attempt to allocate Buffer larger than maximum size: 0x' + s.toString(16) + ' bytes'
                        )
                    return 0 | e
                }
                function g(e, t) {
                    if (u.isBuffer(e)) return e.length
                    if (ArrayBuffer.isView(e) || Q(e, ArrayBuffer)) return e.byteLength
                    if ('string' != typeof e)
                        throw new TypeError(
                            'The "string" argument must be one of type string, Buffer, or ArrayBuffer. Received type ' + typeof e
                        )
                    const r = e.length,
                        n = arguments.length > 2 && !0 === arguments[2]
                    if (!n && 0 === r) return 0
                    let i = !1
                    for (; ;)
                        switch (t) {
                            case 'ascii':
                            case 'latin1':
                            case 'binary':
                                return r
                            case 'utf8':
                            case 'utf-8':
                                return K(e).length
                            case 'ucs2':
                            case 'ucs-2':
                            case 'utf16le':
                            case 'utf-16le':
                                return 2 * r
                            case 'hex':
                                return r >>> 1
                            case 'base64':
                                return V(e).length
                            default:
                                if (i) return n ? -1 : K(e).length
                                    ; (t = ('' + t).toLowerCase()), (i = !0)
                        }
                }
                function h(e, t, r) {
                    let n = !1
                    if (((void 0 === t || t < 0) && (t = 0), t > this.length)) return ''
                    if (((void 0 === r || r > this.length) && (r = this.length), r <= 0)) return ''
                    if ((r >>>= 0) <= (t >>>= 0)) return ''
                    for (e || (e = 'utf8'); ;)
                        switch (e) {
                            case 'hex':
                                return E(this, t, r)
                            case 'utf8':
                            case 'utf-8':
                                return x(this, t, r)
                            case 'ascii':
                                return S(this, t, r)
                            case 'latin1':
                            case 'binary':
                                return I(this, t, r)
                            case 'base64':
                                return j(this, t, r)
                            case 'ucs2':
                            case 'ucs-2':
                            case 'utf16le':
                            case 'utf-16le':
                                return k(this, t, r)
                            default:
                                if (n) throw new TypeError('Unknown encoding: ' + e)
                                    ; (e = (e + '').toLowerCase()), (n = !0)
                        }
                }
                function y(e, t, r) {
                    const n = e[t]
                        ; (e[t] = e[r]), (e[r] = n)
                }
                function b(e, t, r, n, i) {
                    if (0 === e.length) return -1
                    if (
                        ('string' == typeof r
                            ? ((n = r), (r = 0))
                            : r > 2147483647
                                ? (r = 2147483647)
                                : r < -2147483648 && (r = -2147483648),
                            Y((r = +r)) && (r = i ? 0 : e.length - 1),
                            r < 0 && (r = e.length + r),
                            r >= e.length)
                    ) {
                        if (i) return -1
                        r = e.length - 1
                    } else if (r < 0) {
                        if (!i) return -1
                        r = 0
                    }
                    if (('string' == typeof t && (t = u.from(t, n)), u.isBuffer(t)))
                        return 0 === t.length ? -1 : v(e, t, r, n, i)
                    if ('number' == typeof t)
                        return (
                            (t &= 255),
                            'function' == typeof Uint8Array.prototype.indexOf
                                ? i
                                    ? Uint8Array.prototype.indexOf.call(e, t, r)
                                    : Uint8Array.prototype.lastIndexOf.call(e, t, r)
                                : v(e, [t], r, n, i)
                        )
                    throw new TypeError('val must be string, number or Buffer')
                }
                function v(e, t, r, n, i) {
                    let o,
                        s = 1,
                        a = e.length,
                        u = t.length
                    if (
                        void 0 !== n &&
                        ('ucs2' === (n = String(n).toLowerCase()) || 'ucs-2' === n || 'utf16le' === n || 'utf-16le' === n)
                    ) {
                        if (e.length < 2 || t.length < 2) return -1
                            ; (s = 2), (a /= 2), (u /= 2), (r /= 2)
                    }
                    function c(e, t) {
                        return 1 === s ? e[t] : e.readUInt16BE(t * s)
                    }
                    if (i) {
                        let n = -1
                        for (o = r; o < a; o++)
                            if (c(e, o) === c(t, -1 === n ? 0 : o - n)) {
                                if ((-1 === n && (n = o), o - n + 1 === u)) return n * s
                            } else -1 !== n && (o -= o - n), (n = -1)
                    } else
                        for (r + u > a && (r = a - u), o = r; o >= 0; o--) {
                            let r = !0
                            for (let n = 0; n < u; n++)
                                if (c(e, o + n) !== c(t, n)) {
                                    r = !1
                                    break
                                }
                            if (r) return o
                        }
                    return -1
                }
                function _(e, t, r, n) {
                    r = Number(r) || 0
                    const i = e.length - r
                    n ? (n = Number(n)) > i && (n = i) : (n = i)
                    const o = t.length
                    let s
                    for (n > o / 2 && (n = o / 2), s = 0; s < n; ++s) {
                        const n = parseInt(t.substr(2 * s, 2), 16)
                        if (Y(n)) return s
                        e[r + s] = n
                    }
                    return s
                }
                function M(e, t, r, n) {
                    return H(K(t, e.length - r), e, r, n)
                }
                function P(e, t, r, n) {
                    return H(
                        (function (e) {
                            const t = []
                            for (let r = 0; r < e.length; ++r) t.push(255 & e.charCodeAt(r))
                            return t
                        })(t),
                        e,
                        r,
                        n
                    )
                }
                function w(e, t, r, n) {
                    return H(V(t), e, r, n)
                }
                function O(e, t, r, n) {
                    return H(
                        (function (e, t) {
                            let r, n, i
                            const o = []
                            for (let s = 0; s < e.length && !((t -= 2) < 0); ++s)
                                (r = e.charCodeAt(s)), (n = r >> 8), (i = r % 256), o.push(i), o.push(n)
                            return o
                        })(t, e.length - r),
                        e,
                        r,
                        n
                    )
                }
                function j(e, t, r) {
                    return 0 === t && r === e.length ? n.fromByteArray(e) : n.fromByteArray(e.slice(t, r))
                }
                function x(e, t, r) {
                    r = Math.min(e.length, r)
                    const n = []
                    let i = t
                    for (; i < r;) {
                        const t = e[i]
                        let o = null,
                            s = t > 239 ? 4 : t > 223 ? 3 : t > 191 ? 2 : 1
                        if (i + s <= r) {
                            let r, n, a, u
                            switch (s) {
                                case 1:
                                    t < 128 && (o = t)
                                    break
                                case 2:
                                    ; (r = e[i + 1]), 128 == (192 & r) && ((u = ((31 & t) << 6) | (63 & r)), u > 127 && (o = u))
                                    break
                                case 3:
                                    ; (r = e[i + 1]),
                                        (n = e[i + 2]),
                                        128 == (192 & r) &&
                                        128 == (192 & n) &&
                                        ((u = ((15 & t) << 12) | ((63 & r) << 6) | (63 & n)),
                                            u > 2047 && (u < 55296 || u > 57343) && (o = u))
                                    break
                                case 4:
                                    ; (r = e[i + 1]),
                                        (n = e[i + 2]),
                                        (a = e[i + 3]),
                                        128 == (192 & r) &&
                                        128 == (192 & n) &&
                                        128 == (192 & a) &&
                                        ((u = ((15 & t) << 18) | ((63 & r) << 12) | ((63 & n) << 6) | (63 & a)),
                                            u > 65535 && u < 1114112 && (o = u))
                            }
                        }
                        null === o
                            ? ((o = 65533), (s = 1))
                            : o > 65535 && ((o -= 65536), n.push(((o >>> 10) & 1023) | 55296), (o = 56320 | (1023 & o))),
                            n.push(o),
                            (i += s)
                    }
                    return (function (e) {
                        const t = e.length
                        if (t <= C) return String.fromCharCode.apply(String, e)
                        let r = '',
                            n = 0
                        for (; n < t;) r += String.fromCharCode.apply(String, e.slice(n, (n += C)))
                        return r
                    })(n)
                }
                ; (u.TYPED_ARRAY_SUPPORT = (function () {
                    try {
                        const e = new Uint8Array(1),
                            t = {
                                foo: function () {
                                    return 42
                                }
                            }
                        return Object.setPrototypeOf(t, Uint8Array.prototype), Object.setPrototypeOf(e, t), 42 === e.foo()
                    } catch (e) {
                        return !1
                    }
                })()),
                    u.TYPED_ARRAY_SUPPORT ||
                    'undefined' == typeof console ||
                    'function' != typeof console.error ||
                    console.error(
                        'This browser lacks typed array (Uint8Array) support which is required by `buffer` v5.x. Use `buffer` v4.x if you require old browser support.'
                    ),
                    Object.defineProperty(u.prototype, 'parent', {
                        enumerable: !0,
                        get: function () {
                            if (u.isBuffer(this)) return this.buffer
                        }
                    }),
                    Object.defineProperty(u.prototype, 'offset', {
                        enumerable: !0,
                        get: function () {
                            if (u.isBuffer(this)) return this.byteOffset
                        }
                    }),
                    (u.poolSize = 8192),
                    (u.from = function (e, t, r) {
                        return c(e, t, r)
                    }),
                    Object.setPrototypeOf(u.prototype, Uint8Array.prototype),
                    Object.setPrototypeOf(u, Uint8Array),
                    (u.alloc = function (e, t, r) {
                        return (function (e, t, r) {
                            return (
                                l(e), e <= 0 ? a(e) : void 0 !== t ? ('string' == typeof r ? a(e).fill(t, r) : a(e).fill(t)) : a(e)
                            )
                        })(e, t, r)
                    }),
                    (u.allocUnsafe = function (e) {
                        return d(e)
                    }),
                    (u.allocUnsafeSlow = function (e) {
                        return d(e)
                    }),
                    (u.isBuffer = function (e) {
                        return null != e && !0 === e._isBuffer && e !== u.prototype
                    }),
                    (u.compare = function (e, t) {
                        if (
                            (Q(e, Uint8Array) && (e = u.from(e, e.offset, e.byteLength)),
                                Q(t, Uint8Array) && (t = u.from(t, t.offset, t.byteLength)),
                                !u.isBuffer(e) || !u.isBuffer(t))
                        )
                            throw new TypeError('The "buf1", "buf2" arguments must be one of type Buffer or Uint8Array')
                        if (e === t) return 0
                        let r = e.length,
                            n = t.length
                        for (let i = 0, o = Math.min(r, n); i < o; ++i)
                            if (e[i] !== t[i]) {
                                ; (r = e[i]), (n = t[i])
                                break
                            }
                        return r < n ? -1 : n < r ? 1 : 0
                    }),
                    (u.isEncoding = function (e) {
                        switch (String(e).toLowerCase()) {
                            case 'hex':
                            case 'utf8':
                            case 'utf-8':
                            case 'ascii':
                            case 'latin1':
                            case 'binary':
                            case 'base64':
                            case 'ucs2':
                            case 'ucs-2':
                            case 'utf16le':
                            case 'utf-16le':
                                return !0
                            default:
                                return !1
                        }
                    }),
                    (u.concat = function (e, t) {
                        if (!Array.isArray(e)) throw new TypeError('"list" argument must be an Array of Buffers')
                        if (0 === e.length) return u.alloc(0)
                        let r
                        if (void 0 === t) for (t = 0, r = 0; r < e.length; ++r) t += e[r].length
                        const n = u.allocUnsafe(t)
                        let i = 0
                        for (r = 0; r < e.length; ++r) {
                            let t = e[r]
                            if (Q(t, Uint8Array))
                                i + t.length > n.length
                                    ? (u.isBuffer(t) || (t = u.from(t)), t.copy(n, i))
                                    : Uint8Array.prototype.set.call(n, t, i)
                            else {
                                if (!u.isBuffer(t)) throw new TypeError('"list" argument must be an Array of Buffers')
                                t.copy(n, i)
                            }
                            i += t.length
                        }
                        return n
                    }),
                    (u.byteLength = g),
                    (u.prototype._isBuffer = !0),
                    (u.prototype.swap16 = function () {
                        const e = this.length
                        if (e % 2 != 0) throw new RangeError('Buffer size must be a multiple of 16-bits')
                        for (let t = 0; t < e; t += 2) y(this, t, t + 1)
                        return this
                    }),
                    (u.prototype.swap32 = function () {
                        const e = this.length
                        if (e % 4 != 0) throw new RangeError('Buffer size must be a multiple of 32-bits')
                        for (let t = 0; t < e; t += 4) y(this, t, t + 3), y(this, t + 1, t + 2)
                        return this
                    }),
                    (u.prototype.swap64 = function () {
                        const e = this.length
                        if (e % 8 != 0) throw new RangeError('Buffer size must be a multiple of 64-bits')
                        for (let t = 0; t < e; t += 8)
                            y(this, t, t + 7), y(this, t + 1, t + 6), y(this, t + 2, t + 5), y(this, t + 3, t + 4)
                        return this
                    }),
                    (u.prototype.toString = function () {
                        const e = this.length
                        return 0 === e ? '' : 0 === arguments.length ? x(this, 0, e) : h.apply(this, arguments)
                    }),
                    (u.prototype.toLocaleString = u.prototype.toString),
                    (u.prototype.equals = function (e) {
                        if (!u.isBuffer(e)) throw new TypeError('Argument must be a Buffer')
                        return this === e || 0 === u.compare(this, e)
                    }),
                    (u.prototype.inspect = function () {
                        let e = ''
                        const r = t.h2
                        return (
                            (e = this.toString('hex', 0, r)
                                .replace(/(.{2})/g, '$1 ')
                                .trim()),
                            this.length > r && (e += ' ... '),
                            '<Buffer ' + e + '>'
                        )
                    }),
                    o && (u.prototype[o] = u.prototype.inspect),
                    (u.prototype.compare = function (e, t, r, n, i) {
                        if ((Q(e, Uint8Array) && (e = u.from(e, e.offset, e.byteLength)), !u.isBuffer(e)))
                            throw new TypeError(
                                'The "target" argument must be one of type Buffer or Uint8Array. Received type ' + typeof e
                            )
                        if (
                            (void 0 === t && (t = 0),
                                void 0 === r && (r = e ? e.length : 0),
                                void 0 === n && (n = 0),
                                void 0 === i && (i = this.length),
                                t < 0 || r > e.length || n < 0 || i > this.length)
                        )
                            throw new RangeError('out of range index')
                        if (n >= i && t >= r) return 0
                        if (n >= i) return -1
                        if (t >= r) return 1
                        if (this === e) return 0
                        let o = (i >>>= 0) - (n >>>= 0),
                            s = (r >>>= 0) - (t >>>= 0)
                        const a = Math.min(o, s),
                            c = this.slice(n, i),
                            l = e.slice(t, r)
                        for (let e = 0; e < a; ++e)
                            if (c[e] !== l[e]) {
                                ; (o = c[e]), (s = l[e])
                                break
                            }
                        return o < s ? -1 : s < o ? 1 : 0
                    }),
                    (u.prototype.includes = function (e, t, r) {
                        return -1 !== this.indexOf(e, t, r)
                    }),
                    (u.prototype.indexOf = function (e, t, r) {
                        return b(this, e, t, r, !0)
                    }),
                    (u.prototype.lastIndexOf = function (e, t, r) {
                        return b(this, e, t, r, !1)
                    }),
                    (u.prototype.write = function (e, t, r, n) {
                        if (void 0 === t) (n = 'utf8'), (r = this.length), (t = 0)
                        else if (void 0 === r && 'string' == typeof t) (n = t), (r = this.length), (t = 0)
                        else {
                            if (!isFinite(t))
                                throw new Error('Buffer.write(string, encoding, offset[, length]) is no longer supported')
                                ; (t >>>= 0), isFinite(r) ? ((r >>>= 0), void 0 === n && (n = 'utf8')) : ((n = r), (r = void 0))
                        }
                        const i = this.length - t
                        if (((void 0 === r || r > i) && (r = i), (e.length > 0 && (r < 0 || t < 0)) || t > this.length))
                            throw new RangeError('Attempt to write outside buffer bounds')
                        n || (n = 'utf8')
                        let o = !1
                        for (; ;)
                            switch (n) {
                                case 'hex':
                                    return _(this, e, t, r)
                                case 'utf8':
                                case 'utf-8':
                                    return M(this, e, t, r)
                                case 'ascii':
                                case 'latin1':
                                case 'binary':
                                    return P(this, e, t, r)
                                case 'base64':
                                    return w(this, e, t, r)
                                case 'ucs2':
                                case 'ucs-2':
                                case 'utf16le':
                                case 'utf-16le':
                                    return O(this, e, t, r)
                                default:
                                    if (o) throw new TypeError('Unknown encoding: ' + n)
                                        ; (n = ('' + n).toLowerCase()), (o = !0)
                            }
                    }),
                    (u.prototype.toJSON = function () {
                        return { type: 'Buffer', data: Array.prototype.slice.call(this._arr || this, 0) }
                    })
                const C = 4096
                function S(e, t, r) {
                    let n = ''
                    r = Math.min(e.length, r)
                    for (let i = t; i < r; ++i) n += String.fromCharCode(127 & e[i])
                    return n
                }
                function I(e, t, r) {
                    let n = ''
                    r = Math.min(e.length, r)
                    for (let i = t; i < r; ++i) n += String.fromCharCode(e[i])
                    return n
                }
                function E(e, t, r) {
                    const n = e.length
                        ; (!t || t < 0) && (t = 0), (!r || r < 0 || r > n) && (r = n)
                    let i = ''
                    for (let n = t; n < r; ++n) i += J[e[n]]
                    return i
                }
                function k(e, t, r) {
                    const n = e.slice(t, r)
                    let i = ''
                    for (let e = 0; e < n.length - 1; e += 2) i += String.fromCharCode(n[e] + 256 * n[e + 1])
                    return i
                }
                function T(e, t, r) {
                    if (e % 1 != 0 || e < 0) throw new RangeError('offset is not uint')
                    if (e + t > r) throw new RangeError('Trying to access beyond buffer length')
                }
                function B(e, t, r, n, i, o) {
                    if (!u.isBuffer(e)) throw new TypeError('"buffer" argument must be a Buffer instance')
                    if (t > i || t < o) throw new RangeError('"value" argument is out of bounds')
                    if (r + n > e.length) throw new RangeError('Index out of range')
                }
                function A(e, t, r, n, i) {
                    W(t, n, i, e, r, 7)
                    let o = Number(t & BigInt(4294967295))
                        ; (e[r++] = o), (o >>= 8), (e[r++] = o), (o >>= 8), (e[r++] = o), (o >>= 8), (e[r++] = o)
                    let s = Number((t >> BigInt(32)) & BigInt(4294967295))
                    return (e[r++] = s), (s >>= 8), (e[r++] = s), (s >>= 8), (e[r++] = s), (s >>= 8), (e[r++] = s), r
                }
                function L(e, t, r, n, i) {
                    W(t, n, i, e, r, 7)
                    let o = Number(t & BigInt(4294967295))
                        ; (e[r + 7] = o), (o >>= 8), (e[r + 6] = o), (o >>= 8), (e[r + 5] = o), (o >>= 8), (e[r + 4] = o)
                    let s = Number((t >> BigInt(32)) & BigInt(4294967295))
                    return (e[r + 3] = s), (s >>= 8), (e[r + 2] = s), (s >>= 8), (e[r + 1] = s), (s >>= 8), (e[r] = s), r + 8
                }
                function R(e, t, r, n, i, o) {
                    if (r + n > e.length) throw new RangeError('Index out of range')
                    if (r < 0) throw new RangeError('Index out of range')
                }
                function U(e, t, r, n, o) {
                    return (t = +t), (r >>>= 0), o || R(e, 0, r, 4), i.write(e, t, r, n, 23, 4), r + 4
                }
                function F(e, t, r, n, o) {
                    return (t = +t), (r >>>= 0), o || R(e, 0, r, 8), i.write(e, t, r, n, 52, 8), r + 8
                }
                ; (u.prototype.slice = function (e, t) {
                    const r = this.length
                        ; (e = ~~e) < 0 ? (e += r) < 0 && (e = 0) : e > r && (e = r),
                            (t = void 0 === t ? r : ~~t) < 0 ? (t += r) < 0 && (t = 0) : t > r && (t = r),
                            t < e && (t = e)
                    const n = this.subarray(e, t)
                    return Object.setPrototypeOf(n, u.prototype), n
                }),
                    (u.prototype.readUintLE = u.prototype.readUIntLE =
                        function (e, t, r) {
                            ; (e >>>= 0), (t >>>= 0), r || T(e, t, this.length)
                            let n = this[e],
                                i = 1,
                                o = 0
                            for (; ++o < t && (i *= 256);) n += this[e + o] * i
                            return n
                        }),
                    (u.prototype.readUintBE = u.prototype.readUIntBE =
                        function (e, t, r) {
                            ; (e >>>= 0), (t >>>= 0), r || T(e, t, this.length)
                            let n = this[e + --t],
                                i = 1
                            for (; t > 0 && (i *= 256);) n += this[e + --t] * i
                            return n
                        }),
                    (u.prototype.readUint8 = u.prototype.readUInt8 =
                        function (e, t) {
                            return (e >>>= 0), t || T(e, 1, this.length), this[e]
                        }),
                    (u.prototype.readUint16LE = u.prototype.readUInt16LE =
                        function (e, t) {
                            return (e >>>= 0), t || T(e, 2, this.length), this[e] | (this[e + 1] << 8)
                        }),
                    (u.prototype.readUint16BE = u.prototype.readUInt16BE =
                        function (e, t) {
                            return (e >>>= 0), t || T(e, 2, this.length), (this[e] << 8) | this[e + 1]
                        }),
                    (u.prototype.readUint32LE = u.prototype.readUInt32LE =
                        function (e, t) {
                            return (
                                (e >>>= 0),
                                t || T(e, 4, this.length),
                                (this[e] | (this[e + 1] << 8) | (this[e + 2] << 16)) + 16777216 * this[e + 3]
                            )
                        }),
                    (u.prototype.readUint32BE = u.prototype.readUInt32BE =
                        function (e, t) {
                            return (
                                (e >>>= 0),
                                t || T(e, 4, this.length),
                                16777216 * this[e] + ((this[e + 1] << 16) | (this[e + 2] << 8) | this[e + 3])
                            )
                        }),
                    (u.prototype.readBigUInt64LE = Z(function (e) {
                        z((e >>>= 0), 'offset')
                        const t = this[e],
                            r = this[e + 7]
                            ; (void 0 !== t && void 0 !== r) || $(e, this.length - 8)
                        const n = t + 256 * this[++e] + 65536 * this[++e] + this[++e] * 2 ** 24,
                            i = this[++e] + 256 * this[++e] + 65536 * this[++e] + r * 2 ** 24
                        return BigInt(n) + (BigInt(i) << BigInt(32))
                    })),
                    (u.prototype.readBigUInt64BE = Z(function (e) {
                        z((e >>>= 0), 'offset')
                        const t = this[e],
                            r = this[e + 7]
                            ; (void 0 !== t && void 0 !== r) || $(e, this.length - 8)
                        const n = t * 2 ** 24 + 65536 * this[++e] + 256 * this[++e] + this[++e],
                            i = this[++e] * 2 ** 24 + 65536 * this[++e] + 256 * this[++e] + r
                        return (BigInt(n) << BigInt(32)) + BigInt(i)
                    })),
                    (u.prototype.readIntLE = function (e, t, r) {
                        ; (e >>>= 0), (t >>>= 0), r || T(e, t, this.length)
                        let n = this[e],
                            i = 1,
                            o = 0
                        for (; ++o < t && (i *= 256);) n += this[e + o] * i
                        return (i *= 128), n >= i && (n -= Math.pow(2, 8 * t)), n
                    }),
                    (u.prototype.readIntBE = function (e, t, r) {
                        ; (e >>>= 0), (t >>>= 0), r || T(e, t, this.length)
                        let n = t,
                            i = 1,
                            o = this[e + --n]
                        for (; n > 0 && (i *= 256);) o += this[e + --n] * i
                        return (i *= 128), o >= i && (o -= Math.pow(2, 8 * t)), o
                    }),
                    (u.prototype.readInt8 = function (e, t) {
                        return (e >>>= 0), t || T(e, 1, this.length), 128 & this[e] ? -1 * (255 - this[e] + 1) : this[e]
                    }),
                    (u.prototype.readInt16LE = function (e, t) {
                        ; (e >>>= 0), t || T(e, 2, this.length)
                        const r = this[e] | (this[e + 1] << 8)
                        return 32768 & r ? 4294901760 | r : r
                    }),
                    (u.prototype.readInt16BE = function (e, t) {
                        ; (e >>>= 0), t || T(e, 2, this.length)
                        const r = this[e + 1] | (this[e] << 8)
                        return 32768 & r ? 4294901760 | r : r
                    }),
                    (u.prototype.readInt32LE = function (e, t) {
                        return (
                            (e >>>= 0),
                            t || T(e, 4, this.length),
                            this[e] | (this[e + 1] << 8) | (this[e + 2] << 16) | (this[e + 3] << 24)
                        )
                    }),
                    (u.prototype.readInt32BE = function (e, t) {
                        return (
                            (e >>>= 0),
                            t || T(e, 4, this.length),
                            (this[e] << 24) | (this[e + 1] << 16) | (this[e + 2] << 8) | this[e + 3]
                        )
                    }),
                    (u.prototype.readBigInt64LE = Z(function (e) {
                        z((e >>>= 0), 'offset')
                        const t = this[e],
                            r = this[e + 7]
                            ; (void 0 !== t && void 0 !== r) || $(e, this.length - 8)
                        const n = this[e + 4] + 256 * this[e + 5] + 65536 * this[e + 6] + (r << 24)
                        return (BigInt(n) << BigInt(32)) + BigInt(t + 256 * this[++e] + 65536 * this[++e] + this[++e] * 2 ** 24)
                    })),
                    (u.prototype.readBigInt64BE = Z(function (e) {
                        z((e >>>= 0), 'offset')
                        const t = this[e],
                            r = this[e + 7]
                            ; (void 0 !== t && void 0 !== r) || $(e, this.length - 8)
                        const n = (t << 24) + 65536 * this[++e] + 256 * this[++e] + this[++e]
                        return (BigInt(n) << BigInt(32)) + BigInt(this[++e] * 2 ** 24 + 65536 * this[++e] + 256 * this[++e] + r)
                    })),
                    (u.prototype.readFloatLE = function (e, t) {
                        return (e >>>= 0), t || T(e, 4, this.length), i.read(this, e, !0, 23, 4)
                    }),
                    (u.prototype.readFloatBE = function (e, t) {
                        return (e >>>= 0), t || T(e, 4, this.length), i.read(this, e, !1, 23, 4)
                    }),
                    (u.prototype.readDoubleLE = function (e, t) {
                        return (e >>>= 0), t || T(e, 8, this.length), i.read(this, e, !0, 52, 8)
                    }),
                    (u.prototype.readDoubleBE = function (e, t) {
                        return (e >>>= 0), t || T(e, 8, this.length), i.read(this, e, !1, 52, 8)
                    }),
                    (u.prototype.writeUintLE = u.prototype.writeUIntLE =
                        function (e, t, r, n) {
                            ; (e = +e), (t >>>= 0), (r >>>= 0), n || B(this, e, t, r, Math.pow(2, 8 * r) - 1, 0)
                            let i = 1,
                                o = 0
                            for (this[t] = 255 & e; ++o < r && (i *= 256);) this[t + o] = (e / i) & 255
                            return t + r
                        }),
                    (u.prototype.writeUintBE = u.prototype.writeUIntBE =
                        function (e, t, r, n) {
                            ; (e = +e), (t >>>= 0), (r >>>= 0), n || B(this, e, t, r, Math.pow(2, 8 * r) - 1, 0)
                            let i = r - 1,
                                o = 1
                            for (this[t + i] = 255 & e; --i >= 0 && (o *= 256);) this[t + i] = (e / o) & 255
                            return t + r
                        }),
                    (u.prototype.writeUint8 = u.prototype.writeUInt8 =
                        function (e, t, r) {
                            return (e = +e), (t >>>= 0), r || B(this, e, t, 1, 255, 0), (this[t] = 255 & e), t + 1
                        }),
                    (u.prototype.writeUint16LE = u.prototype.writeUInt16LE =
                        function (e, t, r) {
                            return (
                                (e = +e),
                                (t >>>= 0),
                                r || B(this, e, t, 2, 65535, 0),
                                (this[t] = 255 & e),
                                (this[t + 1] = e >>> 8),
                                t + 2
                            )
                        }),
                    (u.prototype.writeUint16BE = u.prototype.writeUInt16BE =
                        function (e, t, r) {
                            return (
                                (e = +e),
                                (t >>>= 0),
                                r || B(this, e, t, 2, 65535, 0),
                                (this[t] = e >>> 8),
                                (this[t + 1] = 255 & e),
                                t + 2
                            )
                        }),
                    (u.prototype.writeUint32LE = u.prototype.writeUInt32LE =
                        function (e, t, r) {
                            return (
                                (e = +e),
                                (t >>>= 0),
                                r || B(this, e, t, 4, 4294967295, 0),
                                (this[t + 3] = e >>> 24),
                                (this[t + 2] = e >>> 16),
                                (this[t + 1] = e >>> 8),
                                (this[t] = 255 & e),
                                t + 4
                            )
                        }),
                    (u.prototype.writeUint32BE = u.prototype.writeUInt32BE =
                        function (e, t, r) {
                            return (
                                (e = +e),
                                (t >>>= 0),
                                r || B(this, e, t, 4, 4294967295, 0),
                                (this[t] = e >>> 24),
                                (this[t + 1] = e >>> 16),
                                (this[t + 2] = e >>> 8),
                                (this[t + 3] = 255 & e),
                                t + 4
                            )
                        }),
                    (u.prototype.writeBigUInt64LE = Z(function (e, t = 0) {
                        return A(this, e, t, BigInt(0), BigInt('0xffffffffffffffff'))
                    })),
                    (u.prototype.writeBigUInt64BE = Z(function (e, t = 0) {
                        return L(this, e, t, BigInt(0), BigInt('0xffffffffffffffff'))
                    })),
                    (u.prototype.writeIntLE = function (e, t, r, n) {
                        if (((e = +e), (t >>>= 0), !n)) {
                            const n = Math.pow(2, 8 * r - 1)
                            B(this, e, t, r, n - 1, -n)
                        }
                        let i = 0,
                            o = 1,
                            s = 0
                        for (this[t] = 255 & e; ++i < r && (o *= 256);)
                            e < 0 && 0 === s && 0 !== this[t + i - 1] && (s = 1), (this[t + i] = (((e / o) >> 0) - s) & 255)
                        return t + r
                    }),
                    (u.prototype.writeIntBE = function (e, t, r, n) {
                        if (((e = +e), (t >>>= 0), !n)) {
                            const n = Math.pow(2, 8 * r - 1)
                            B(this, e, t, r, n - 1, -n)
                        }
                        let i = r - 1,
                            o = 1,
                            s = 0
                        for (this[t + i] = 255 & e; --i >= 0 && (o *= 256);)
                            e < 0 && 0 === s && 0 !== this[t + i + 1] && (s = 1), (this[t + i] = (((e / o) >> 0) - s) & 255)
                        return t + r
                    }),
                    (u.prototype.writeInt8 = function (e, t, r) {
                        return (
                            (e = +e),
                            (t >>>= 0),
                            r || B(this, e, t, 1, 127, -128),
                            e < 0 && (e = 255 + e + 1),
                            (this[t] = 255 & e),
                            t + 1
                        )
                    }),
                    (u.prototype.writeInt16LE = function (e, t, r) {
                        return (
                            (e = +e),
                            (t >>>= 0),
                            r || B(this, e, t, 2, 32767, -32768),
                            (this[t] = 255 & e),
                            (this[t + 1] = e >>> 8),
                            t + 2
                        )
                    }),
                    (u.prototype.writeInt16BE = function (e, t, r) {
                        return (
                            (e = +e),
                            (t >>>= 0),
                            r || B(this, e, t, 2, 32767, -32768),
                            (this[t] = e >>> 8),
                            (this[t + 1] = 255 & e),
                            t + 2
                        )
                    }),
                    (u.prototype.writeInt32LE = function (e, t, r) {
                        return (
                            (e = +e),
                            (t >>>= 0),
                            r || B(this, e, t, 4, 2147483647, -2147483648),
                            (this[t] = 255 & e),
                            (this[t + 1] = e >>> 8),
                            (this[t + 2] = e >>> 16),
                            (this[t + 3] = e >>> 24),
                            t + 4
                        )
                    }),
                    (u.prototype.writeInt32BE = function (e, t, r) {
                        return (
                            (e = +e),
                            (t >>>= 0),
                            r || B(this, e, t, 4, 2147483647, -2147483648),
                            e < 0 && (e = 4294967295 + e + 1),
                            (this[t] = e >>> 24),
                            (this[t + 1] = e >>> 16),
                            (this[t + 2] = e >>> 8),
                            (this[t + 3] = 255 & e),
                            t + 4
                        )
                    }),
                    (u.prototype.writeBigInt64LE = Z(function (e, t = 0) {
                        return A(this, e, t, -BigInt('0x8000000000000000'), BigInt('0x7fffffffffffffff'))
                    })),
                    (u.prototype.writeBigInt64BE = Z(function (e, t = 0) {
                        return L(this, e, t, -BigInt('0x8000000000000000'), BigInt('0x7fffffffffffffff'))
                    })),
                    (u.prototype.writeFloatLE = function (e, t, r) {
                        return U(this, e, t, !0, r)
                    }),
                    (u.prototype.writeFloatBE = function (e, t, r) {
                        return U(this, e, t, !1, r)
                    }),
                    (u.prototype.writeDoubleLE = function (e, t, r) {
                        return F(this, e, t, !0, r)
                    }),
                    (u.prototype.writeDoubleBE = function (e, t, r) {
                        return F(this, e, t, !1, r)
                    }),
                    (u.prototype.copy = function (e, t, r, n) {
                        if (!u.isBuffer(e)) throw new TypeError('argument should be a Buffer')
                        if (
                            (r || (r = 0),
                                n || 0 === n || (n = this.length),
                                t >= e.length && (t = e.length),
                                t || (t = 0),
                                n > 0 && n < r && (n = r),
                                n === r)
                        )
                            return 0
                        if (0 === e.length || 0 === this.length) return 0
                        if (t < 0) throw new RangeError('targetStart out of bounds')
                        if (r < 0 || r >= this.length) throw new RangeError('Index out of range')
                        if (n < 0) throw new RangeError('sourceEnd out of bounds')
                        n > this.length && (n = this.length), e.length - t < n - r && (n = e.length - t + r)
                        const i = n - r
                        return (
                            this === e && 'function' == typeof Uint8Array.prototype.copyWithin
                                ? this.copyWithin(t, r, n)
                                : Uint8Array.prototype.set.call(e, this.subarray(r, n), t),
                            i
                        )
                    }),
                    (u.prototype.fill = function (e, t, r, n) {
                        if ('string' == typeof e) {
                            if (
                                ('string' == typeof t
                                    ? ((n = t), (t = 0), (r = this.length))
                                    : 'string' == typeof r && ((n = r), (r = this.length)),
                                    void 0 !== n && 'string' != typeof n)
                            )
                                throw new TypeError('encoding must be a string')
                            if ('string' == typeof n && !u.isEncoding(n)) throw new TypeError('Unknown encoding: ' + n)
                            if (1 === e.length) {
                                const t = e.charCodeAt(0)
                                    ; (('utf8' === n && t < 128) || 'latin1' === n) && (e = t)
                            }
                        } else 'number' == typeof e ? (e &= 255) : 'boolean' == typeof e && (e = Number(e))
                        if (t < 0 || this.length < t || this.length < r) throw new RangeError('Out of range index')
                        if (r <= t) return this
                        let i
                        if (((t >>>= 0), (r = void 0 === r ? this.length : r >>> 0), e || (e = 0), 'number' == typeof e))
                            for (i = t; i < r; ++i) this[i] = e
                        else {
                            const o = u.isBuffer(e) ? e : u.from(e, n),
                                s = o.length
                            if (0 === s) throw new TypeError('The value "' + e + '" is invalid for argument "value"')
                            for (i = 0; i < r - t; ++i) this[i + t] = o[i % s]
                        }
                        return this
                    })
                const D = {}
                function G(e, t, r) {
                    D[e] = class extends r {
                        constructor() {
                            super(),
                                Object.defineProperty(this, 'message', {
                                    value: t.apply(this, arguments),
                                    writable: !0,
                                    configurable: !0
                                }),
                                (this.name = `${this.name} [${e}]`),
                                this.stack,
                                delete this.name
                        }
                        get code() {
                            return e
                        }
                        set code(e) {
                            Object.defineProperty(this, 'code', { configurable: !0, enumerable: !0, value: e, writable: !0 })
                        }
                        toString() {
                            return `${this.name} [${e}]: ${this.message}`
                        }
                    }
                }
                function N(e) {
                    let t = '',
                        r = e.length
                    const n = '-' === e[0] ? 1 : 0
                    for (; r >= n + 4; r -= 3) t = `_${e.slice(r - 3, r)}${t}`
                    return `${e.slice(0, r)}${t}`
                }
                function W(e, t, r, n, i, o) {
                    if (e > r || e < t) {
                        const n = 'bigint' == typeof t ? 'n' : ''
                        let i
                        throw (
                            ((i =
                                o > 3
                                    ? 0 === t || t === BigInt(0)
                                        ? `>= 0${n} and < 2${n} ** ${8 * (o + 1)}${n}`
                                        : `>= -(2${n} ** ${8 * (o + 1) - 1}${n}) and < 2 ** ${8 * (o + 1) - 1}${n}`
                                    : `>= ${t}${n} and <= ${r}${n}`),
                                new D.ERR_OUT_OF_RANGE('value', i, e))
                        )
                    }
                    !(function (e, t, r) {
                        z(t, 'offset'), (void 0 !== e[t] && void 0 !== e[t + r]) || $(t, e.length - (r + 1))
                    })(n, i, o)
                }
                function z(e, t) {
                    if ('number' != typeof e) throw new D.ERR_INVALID_ARG_TYPE(t, 'number', e)
                }
                function $(e, t, r) {
                    if (Math.floor(e) !== e) throw (z(e, r), new D.ERR_OUT_OF_RANGE(r || 'offset', 'an integer', e))
                    if (t < 0) throw new D.ERR_BUFFER_OUT_OF_BOUNDS()
                    throw new D.ERR_OUT_OF_RANGE(r || 'offset', `>= ${r ? 1 : 0} and <= ${t}`, e)
                }
                G(
                    'ERR_BUFFER_OUT_OF_BOUNDS',
                    function (e) {
                        return e ? `${e} is outside of buffer bounds` : 'Attempt to access memory outside buffer bounds'
                    },
                    RangeError
                ),
                    G(
                        'ERR_INVALID_ARG_TYPE',
                        function (e, t) {
                            return `The "${e}" argument must be of type number. Received type ${typeof t}`
                        },
                        TypeError
                    ),
                    G(
                        'ERR_OUT_OF_RANGE',
                        function (e, t, r) {
                            let n = `The value of "${e}" is out of range.`,
                                i = r
                            return (
                                Number.isInteger(r) && Math.abs(r) > 2 ** 32
                                    ? (i = N(String(r)))
                                    : 'bigint' == typeof r &&
                                    ((i = String(r)),
                                        (r > BigInt(2) ** BigInt(32) || r < -(BigInt(2) ** BigInt(32))) && (i = N(i)),
                                        (i += 'n')),
                                (n += ` It must be ${t}. Received ${i}`),
                                n
                            )
                        },
                        RangeError
                    )
                const q = /[^+/0-9A-Za-z-_]/g
                function K(e, t) {
                    let r
                    t = t || 1 / 0
                    const n = e.length
                    let i = null
                    const o = []
                    for (let s = 0; s < n; ++s) {
                        if (((r = e.charCodeAt(s)), r > 55295 && r < 57344)) {
                            if (!i) {
                                if (r > 56319) {
                                    ; (t -= 3) > -1 && o.push(239, 191, 189)
                                    continue
                                }
                                if (s + 1 === n) {
                                    ; (t -= 3) > -1 && o.push(239, 191, 189)
                                    continue
                                }
                                i = r
                                continue
                            }
                            if (r < 56320) {
                                ; (t -= 3) > -1 && o.push(239, 191, 189), (i = r)
                                continue
                            }
                            r = 65536 + (((i - 55296) << 10) | (r - 56320))
                        } else i && (t -= 3) > -1 && o.push(239, 191, 189)
                        if (((i = null), r < 128)) {
                            if ((t -= 1) < 0) break
                            o.push(r)
                        } else if (r < 2048) {
                            if ((t -= 2) < 0) break
                            o.push((r >> 6) | 192, (63 & r) | 128)
                        } else if (r < 65536) {
                            if ((t -= 3) < 0) break
                            o.push((r >> 12) | 224, ((r >> 6) & 63) | 128, (63 & r) | 128)
                        } else {
                            if (!(r < 1114112)) throw new Error('Invalid code point')
                            if ((t -= 4) < 0) break
                            o.push((r >> 18) | 240, ((r >> 12) & 63) | 128, ((r >> 6) & 63) | 128, (63 & r) | 128)
                        }
                    }
                    return o
                }
                function V(e) {
                    return n.toByteArray(
                        (function (e) {
                            if ((e = (e = e.split('=')[0]).trim().replace(q, '')).length < 2) return ''
                            for (; e.length % 4 != 0;) e += '='
                            return e
                        })(e)
                    )
                }
                function H(e, t, r, n) {
                    let i
                    for (i = 0; i < n && !(i + r >= t.length || i >= e.length); ++i) t[i + r] = e[i]
                    return i
                }
                function Q(e, t) {
                    return (
                        e instanceof t ||
                        (null != e && null != e.constructor && null != e.constructor.name && e.constructor.name === t.name)
                    )
                }
                function Y(e) {
                    return e != e
                }
                const J = (function () {
                    const e = '0123456789abcdef',
                        t = new Array(256)
                    for (let r = 0; r < 16; ++r) {
                        const n = 16 * r
                        for (let i = 0; i < 16; ++i) t[n + i] = e[r] + e[i]
                    }
                    return t
                })()
                function Z(e) {
                    return 'undefined' == typeof BigInt ? X : e
                }
                function X() {
                    throw new Error('BigInt not supported')
                }
            },
            1118: function (e) {
                e.exports = (function () {
                    'use strict'
                    function e(e, t) {
                        var r = Object.keys(e)
                        if (Object.getOwnPropertySymbols) {
                            var n = Object.getOwnPropertySymbols(e)
                            t &&
                                (n = n.filter(function (t) {
                                    return Object.getOwnPropertyDescriptor(e, t).enumerable
                                })),
                                r.push.apply(r, n)
                        }
                        return r
                    }
                    function t(t) {
                        for (var r = 1; r < arguments.length; r++) {
                            var i = null != arguments[r] ? arguments[r] : {}
                            r % 2
                                ? e(Object(i), !0).forEach(function (e) {
                                    n(t, e, i[e])
                                })
                                : Object.getOwnPropertyDescriptors
                                    ? Object.defineProperties(t, Object.getOwnPropertyDescriptors(i))
                                    : e(Object(i)).forEach(function (e) {
                                        Object.defineProperty(t, e, Object.getOwnPropertyDescriptor(i, e))
                                    })
                        }
                        return t
                    }
                    function r(e, t) {
                        for (var r = 0; r < t.length; r++) {
                            var n = t[r]
                                ; (n.enumerable = n.enumerable || !1),
                                    (n.configurable = !0),
                                    'value' in n && (n.writable = !0),
                                    Object.defineProperty(e, n.key, n)
                        }
                    }
                    function n(e, t, r) {
                        return (
                            t in e
                                ? Object.defineProperty(e, t, { value: r, enumerable: !0, configurable: !0, writable: !0 })
                                : (e[t] = r),
                            e
                        )
                    }
                    function i() {
                        return (
                            (i =
                                Object.assign ||
                                function (e) {
                                    for (var t = 1; t < arguments.length; t++) {
                                        var r = arguments[t]
                                        for (var n in r) Object.prototype.hasOwnProperty.call(r, n) && (e[n] = r[n])
                                    }
                                    return e
                                }),
                            i.apply(this, arguments)
                        )
                    }
                    var o = { exports: {} }
                    !(function (e) {
                        'undefined' != typeof window &&
                            (function (t) {
                                var r = t.HTMLCanvasElement && t.HTMLCanvasElement.prototype,
                                    n =
                                        t.Blob &&
                                        (function () {
                                            try {
                                                return Boolean(new Blob())
                                            } catch (e) {
                                                return !1
                                            }
                                        })(),
                                    i =
                                        n &&
                                        t.Uint8Array &&
                                        (function () {
                                            try {
                                                return 100 === new Blob([new Uint8Array(100)]).size
                                            } catch (e) {
                                                return !1
                                            }
                                        })(),
                                    o = t.BlobBuilder || t.WebKitBlobBuilder || t.MozBlobBuilder || t.MSBlobBuilder,
                                    s = /^data:((.*?)(;charset=.*?)?)(;base64)?,/,
                                    a =
                                        (n || o) &&
                                        t.atob &&
                                        t.ArrayBuffer &&
                                        t.Uint8Array &&
                                        function (e) {
                                            var t, r, a, u, c, l, d, f, p
                                            if (!(t = e.match(s))) throw new Error('invalid data URI')
                                            for (
                                                r = t[2] ? t[1] : 'text/plain' + (t[3] || ';charset=US-ASCII'),
                                                a = !!t[4],
                                                u = e.slice(t[0].length),
                                                c = a ? atob(u) : decodeURIComponent(u),
                                                l = new ArrayBuffer(c.length),
                                                d = new Uint8Array(l),
                                                f = 0;
                                                f < c.length;
                                                f += 1
                                            )
                                                d[f] = c.charCodeAt(f)
                                            return n ? new Blob([i ? d : l], { type: r }) : ((p = new o()).append(l), p.getBlob(r))
                                        }
                                t.HTMLCanvasElement &&
                                    !r.toBlob &&
                                    (r.mozGetAsFile
                                        ? (r.toBlob = function (e, t, n) {
                                            var i = this
                                            setTimeout(function () {
                                                n && r.toDataURL && a ? e(a(i.toDataURL(t, n))) : e(i.mozGetAsFile('blob', t))
                                            })
                                        })
                                        : r.toDataURL &&
                                        a &&
                                        (r.msToBlob
                                            ? (r.toBlob = function (e, t, n) {
                                                var i = this
                                                setTimeout(function () {
                                                    ; ((t && 'image/png' !== t) || n) && r.toDataURL && a
                                                        ? e(a(i.toDataURL(t, n)))
                                                        : e(i.msToBlob(t))
                                                })
                                            })
                                            : (r.toBlob = function (e, t, r) {
                                                var n = this
                                                setTimeout(function () {
                                                    e(a(n.toDataURL(t, r)))
                                                })
                                            }))),
                                    e.exports ? (e.exports = a) : (t.dataURLtoBlob = a)
                            })(window)
                    })(o)
                    var s = o.exports,
                        a = {
                            strict: !0,
                            checkOrientation: !0,
                            maxWidth: 1 / 0,
                            maxHeight: 1 / 0,
                            minWidth: 0,
                            minHeight: 0,
                            width: void 0,
                            height: void 0,
                            resize: 'none',
                            quality: 0.8,
                            mimeType: 'auto',
                            convertTypes: ['image/png'],
                            convertSize: 5e6,
                            beforeDraw: null,
                            drew: null,
                            success: null,
                            error: null
                        },
                        u = 'undefined' != typeof window && void 0 !== window.document ? window : {},
                        c = function (e) {
                            return e > 0 && e < 1 / 0
                        },
                        l = Array.prototype.slice
                    var d = /^image\/.+$/
                    function f(e) {
                        return d.test(e)
                    }
                    var p = String.fromCharCode
                    var m = u.btoa
                    function g(e) {
                        var t,
                            r = new DataView(e)
                        try {
                            var n, i, o
                            if (255 === r.getUint8(0) && 216 === r.getUint8(1))
                                for (var s = r.byteLength, a = 2; a + 1 < s;) {
                                    if (255 === r.getUint8(a) && 225 === r.getUint8(a + 1)) {
                                        i = a
                                        break
                                    }
                                    a += 1
                                }
                            if (i) {
                                var u = i + 10
                                if (
                                    'Exif' ===
                                    (function (e, t, r) {
                                        var n,
                                            i = ''
                                        for (r += t, n = t; n < r; n += 1) i += p(e.getUint8(n))
                                        return i
                                    })(r, i + 4, 4)
                                ) {
                                    var c = r.getUint16(u)
                                    if (((n = 18761 === c) || 19789 === c) && 42 === r.getUint16(u + 2, n)) {
                                        var l = r.getUint32(u + 4, n)
                                        l >= 8 && (o = u + l)
                                    }
                                }
                            }
                            if (o) {
                                var d,
                                    f,
                                    m = r.getUint16(o, n)
                                for (f = 0; f < m; f += 1)
                                    if (((d = o + 12 * f + 2), 274 === r.getUint16(d, n))) {
                                        ; (d += 8), (t = r.getUint16(d, n)), r.setUint16(d, 1, n)
                                        break
                                    }
                            }
                        } catch (e) {
                            t = 1
                        }
                        return t
                    }
                    var h = /\.\d*(?:0|9){12}\d*$/
                    function y(e) {
                        var t = arguments.length > 1 && void 0 !== arguments[1] ? arguments[1] : 1e11
                        return h.test(e) ? Math.round(e * t) / t : e
                    }
                    function b(e) {
                        var t = e.aspectRatio,
                            r = e.height,
                            n = e.width,
                            i = arguments.length > 1 && void 0 !== arguments[1] ? arguments[1] : 'none',
                            o = c(n),
                            s = c(r)
                        if (o && s) {
                            var a = r * t
                                ; (('contain' === i || 'none' === i) && a > n) || ('cover' === i && a < n) ? (r = n / t) : (n = r * t)
                        } else o ? (r = n / t) : s && (n = r * t)
                        return { width: n, height: r }
                    }
                    var v = u.ArrayBuffer,
                        _ = u.FileReader,
                        M = u.URL || u.webkitURL,
                        P = /\.\w+$/,
                        w = u.Compressor
                    return (function () {
                        function e(r, n) {
                            ; (function (e, t) {
                                if (!(e instanceof t)) throw new TypeError('Cannot call a class as a function')
                            })(this, e),
                                (this.file = r),
                                (this.image = new Image()),
                                (this.options = t(t({}, a), n)),
                                (this.aborted = !1),
                                (this.result = null),
                                this.init()
                        }
                        return (
                            (n = e),
                            (d = [
                                {
                                    key: 'noConflict',
                                    value: function () {
                                        return (window.Compressor = w), e
                                    }
                                },
                                {
                                    key: 'setDefaults',
                                    value: function (e) {
                                        i(a, e)
                                    }
                                }
                            ]),
                            (o = [
                                {
                                    key: 'init',
                                    value: function () {
                                        var e,
                                            t = this,
                                            r = this.file,
                                            n = this.options
                                        if (
                                            ((e = r),
                                                'undefined' != typeof Blob &&
                                                (e instanceof Blob || '[object Blob]' === Object.prototype.toString.call(e)))
                                        ) {
                                            var o = r.type
                                            if (f(o))
                                                if (M && _)
                                                    if ((v || (n.checkOrientation = !1), M && !n.checkOrientation))
                                                        this.load({ url: M.createObjectURL(r) })
                                                    else {
                                                        var s = new _(),
                                                            a = n.checkOrientation && 'image/jpeg' === o
                                                            ; (this.reader = s),
                                                                (s.onload = function (e) {
                                                                    var n = e.target.result,
                                                                        s = {}
                                                                    if (a) {
                                                                        var u = g(n)
                                                                        u > 1 || !M
                                                                            ? ((s.url = (function (e, t) {
                                                                                for (var r = [], n = new Uint8Array(e); n.length > 0;)
                                                                                    r.push(
                                                                                        p.apply(
                                                                                            null,
                                                                                            ((i = n.subarray(0, 8192)), Array.from ? Array.from(i) : l.call(i))
                                                                                        )
                                                                                    ),
                                                                                        (n = n.subarray(8192))
                                                                                var i
                                                                                return 'data:'.concat(t, ';base64,').concat(m(r.join('')))
                                                                            })(n, o)),
                                                                                u > 1 &&
                                                                                i(
                                                                                    s,
                                                                                    (function (e) {
                                                                                        var t = 0,
                                                                                            r = 1,
                                                                                            n = 1
                                                                                        switch (e) {
                                                                                            case 2:
                                                                                                r = -1
                                                                                                break
                                                                                            case 3:
                                                                                                t = -180
                                                                                                break
                                                                                            case 4:
                                                                                                n = -1
                                                                                                break
                                                                                            case 5:
                                                                                                ; (t = 90), (n = -1)
                                                                                                break
                                                                                            case 6:
                                                                                                t = 90
                                                                                                break
                                                                                            case 7:
                                                                                                ; (t = 90), (r = -1)
                                                                                                break
                                                                                            case 8:
                                                                                                t = -90
                                                                                        }
                                                                                        return { rotate: t, scaleX: r, scaleY: n }
                                                                                    })(u)
                                                                                ))
                                                                            : (s.url = M.createObjectURL(r))
                                                                    } else s.url = n
                                                                    t.load(s)
                                                                }),
                                                                (s.onabort = function () {
                                                                    t.fail(new Error('Aborted to read the image with FileReader.'))
                                                                }),
                                                                (s.onerror = function () {
                                                                    t.fail(new Error('Failed to read the image with FileReader.'))
                                                                }),
                                                                (s.onloadend = function () {
                                                                    t.reader = null
                                                                }),
                                                                a ? s.readAsArrayBuffer(r) : s.readAsDataURL(r)
                                                    }
                                                else this.fail(new Error('The current browser does not support image compression.'))
                                            else this.fail(new Error('The first argument must be an image File or Blob object.'))
                                        } else this.fail(new Error('The first argument must be a File or Blob object.'))
                                    }
                                },
                                {
                                    key: 'load',
                                    value: function (e) {
                                        var r = this,
                                            n = this.file,
                                            i = this.image
                                            ; (i.onload = function () {
                                                r.draw(t(t({}, e), {}, { naturalWidth: i.naturalWidth, naturalHeight: i.naturalHeight }))
                                            }),
                                                (i.onabort = function () {
                                                    r.fail(new Error('Aborted to load the image.'))
                                                }),
                                                (i.onerror = function () {
                                                    r.fail(new Error('Failed to load the image.'))
                                                }),
                                                u.navigator &&
                                                /(?:iPad|iPhone|iPod).*?AppleWebKit/i.test(u.navigator.userAgent) &&
                                                (i.crossOrigin = 'anonymous'),
                                                (i.alt = n.name),
                                                (i.src = e.url)
                                    }
                                },
                                {
                                    key: 'draw',
                                    value: function (e) {
                                        var t = this,
                                            r = e.naturalWidth,
                                            n = e.naturalHeight,
                                            i = e.rotate,
                                            o = void 0 === i ? 0 : i,
                                            a = e.scaleX,
                                            u = void 0 === a ? 1 : a,
                                            l = e.scaleY,
                                            d = void 0 === l ? 1 : l,
                                            p = this.file,
                                            m = this.image,
                                            g = this.options,
                                            h = document.createElement('canvas'),
                                            v = h.getContext('2d'),
                                            _ = Math.abs(o) % 180 == 90,
                                            M = ('contain' === g.resize || 'cover' === g.resize) && c(g.width) && c(g.height),
                                            P = Math.max(g.maxWidth, 0) || 1 / 0,
                                            w = Math.max(g.maxHeight, 0) || 1 / 0,
                                            O = Math.max(g.minWidth, 0) || 0,
                                            j = Math.max(g.minHeight, 0) || 0,
                                            x = r / n,
                                            C = g.width,
                                            S = g.height
                                        if (_) {
                                            var I = [w, P]
                                                ; (P = I[0]), (w = I[1])
                                            var E = [j, O]
                                                ; (O = E[0]), (j = E[1])
                                            var k = [S, C]
                                                ; (C = k[0]), (S = k[1])
                                        }
                                        M && (x = C / S)
                                        var T = b({ aspectRatio: x, width: P, height: w }, 'contain')
                                            ; (P = T.width), (w = T.height)
                                        var B = b({ aspectRatio: x, width: O, height: j }, 'cover')
                                        if (((O = B.width), (j = B.height), M)) {
                                            var A = b({ aspectRatio: x, width: C, height: S }, g.resize)
                                                ; (C = A.width), (S = A.height)
                                        } else {
                                            var L = b({ aspectRatio: x, width: C, height: S }),
                                                R = L.width
                                            C = void 0 === R ? r : R
                                            var U = L.height
                                            S = void 0 === U ? n : U
                                        }
                                        var F = -(C = Math.floor(y(Math.min(Math.max(C, O), P)))) / 2,
                                            D = -(S = Math.floor(y(Math.min(Math.max(S, j), w)))) / 2,
                                            G = C,
                                            N = S,
                                            W = []
                                        if (M) {
                                            var z,
                                                $,
                                                q,
                                                K,
                                                V = b(
                                                    { aspectRatio: x, width: r, height: n },
                                                    { contain: 'cover', cover: 'contain' }[g.resize]
                                                )
                                                ; (q = V.width), (K = V.height), (z = (r - q) / 2), ($ = (n - K) / 2), W.push(z, $, q, K)
                                        }
                                        if ((W.push(F, D, G, N), _)) {
                                            var H = [S, C]
                                                ; (C = H[0]), (S = H[1])
                                        }
                                        ; (h.width = C), (h.height = S), f(g.mimeType) || (g.mimeType = p.type)
                                        var Q = 'transparent'
                                        if (
                                            (p.size > g.convertSize &&
                                                g.convertTypes.indexOf(g.mimeType) >= 0 &&
                                                (g.mimeType = 'image/jpeg'),
                                                'image/jpeg' === g.mimeType && (Q = '#fff'),
                                                (v.fillStyle = Q),
                                                v.fillRect(0, 0, C, S),
                                                g.beforeDraw && g.beforeDraw.call(this, v, h),
                                                !this.aborted &&
                                                (v.save(),
                                                    v.translate(C / 2, S / 2),
                                                    v.rotate((o * Math.PI) / 180),
                                                    v.scale(u, d),
                                                    v.drawImage.apply(v, [m].concat(W)),
                                                    v.restore(),
                                                    g.drew && g.drew.call(this, v, h),
                                                    !this.aborted))
                                        ) {
                                            var Y = function (e) {
                                                t.aborted || t.done({ naturalWidth: r, naturalHeight: n, result: e })
                                            }
                                            h.toBlob ? h.toBlob(Y, g.mimeType, g.quality) : Y(s(h.toDataURL(g.mimeType, g.quality)))
                                        }
                                    }
                                },
                                {
                                    key: 'done',
                                    value: function (e) {
                                        var t,
                                            r,
                                            n = e.naturalWidth,
                                            i = e.naturalHeight,
                                            o = e.result,
                                            s = this.file,
                                            a = this.image,
                                            u = this.options
                                        if ((M && !u.checkOrientation && M.revokeObjectURL(a.src), o))
                                            if (
                                                u.strict &&
                                                o.size > s.size &&
                                                u.mimeType === s.type &&
                                                !(
                                                    u.width > n ||
                                                    u.height > i ||
                                                    u.minWidth > n ||
                                                    u.minHeight > i ||
                                                    u.maxWidth < n ||
                                                    u.maxHeight < i
                                                )
                                            )
                                                o = s
                                            else {
                                                var c = new Date()
                                                    ; (o.lastModified = c.getTime()),
                                                        (o.lastModifiedDate = c),
                                                        (o.name = s.name),
                                                        o.name &&
                                                        o.type !== s.type &&
                                                        (o.name = o.name.replace(
                                                            P,
                                                            ((t = o.type), 'jpeg' === (r = f(t) ? t.substr(6) : '') && (r = 'jpg'), '.'.concat(r))
                                                        ))
                                            }
                                        else o = s
                                            ; (this.result = o), u.success && u.success.call(this, o)
                                    }
                                },
                                {
                                    key: 'fail',
                                    value: function (e) {
                                        var t = this.options
                                        if (!t.error) throw e
                                        t.error.call(this, e)
                                    }
                                },
                                {
                                    key: 'abort',
                                    value: function () {
                                        this.aborted ||
                                            ((this.aborted = !0),
                                                this.reader
                                                    ? this.reader.abort()
                                                    : this.image.complete
                                                        ? this.fail(new Error('The compression process has been aborted.'))
                                                        : ((this.image.onload = null), this.image.onabort()))
                                    }
                                }
                            ]) && r(n.prototype, o),
                            d && r(n, d),
                            e
                        )
                        var n, o, d
                    })()
                })()
            },
            840: (e, t, r) => {
                ; (t.formatArgs = function (t) {
                    if (
                        ((t[0] =
                            (this.useColors ? '%c' : '') +
                            this.namespace +
                            (this.useColors ? ' %c' : ' ') +
                            t[0] +
                            (this.useColors ? '%c ' : ' ') +
                            '+' +
                            e.exports.humanize(this.diff)),
                            !this.useColors)
                    )
                        return
                    const r = 'color: ' + this.color
                    t.splice(1, 0, r, 'color: inherit')
                    let n = 0,
                        i = 0
                    t[0].replace(/%[a-zA-Z%]/g, (e) => {
                        '%%' !== e && (n++, '%c' === e && (i = n))
                    }),
                        t.splice(i, 0, r)
                }),
                    (t.save = function (e) {
                        try {
                            e ? t.storage.setItem('debug', e) : t.storage.removeItem('debug')
                        } catch (e) { }
                    }),
                    (t.load = function () {
                        let e
                        try {
                            e = t.storage.getItem('debug')
                        } catch (e) { }
                        return !e && 'undefined' != typeof process && 'env' in process && (e = process.env.DEBUG), e
                    }),
                    (t.useColors = function () {
                        return (
                            !(
                                'undefined' == typeof window ||
                                !window.process ||
                                ('renderer' !== window.process.type && !window.process.__nwjs)
                            ) ||
                            (('undefined' == typeof navigator ||
                                !navigator.userAgent ||
                                !navigator.userAgent.toLowerCase().match(/(edge|trident)\/(\d+)/)) &&
                                (('undefined' != typeof document &&
                                    document.documentElement &&
                                    document.documentElement.style &&
                                    document.documentElement.style.WebkitAppearance) ||
                                    ('undefined' != typeof window &&
                                        window.console &&
                                        (window.console.firebug || (window.console.exception && window.console.table))) ||
                                    ('undefined' != typeof navigator &&
                                        navigator.userAgent &&
                                        navigator.userAgent.toLowerCase().match(/firefox\/(\d+)/) &&
                                        parseInt(RegExp.$1, 10) >= 31) ||
                                    ('undefined' != typeof navigator &&
                                        navigator.userAgent &&
                                        navigator.userAgent.toLowerCase().match(/applewebkit\/(\d+)/))))
                        )
                    }),
                    (t.storage = (function () {
                        try {
                            return localStorage
                        } catch (e) { }
                    })()),
                    (t.destroy = (() => {
                        let e = !1
                        return () => {
                            e ||
                                ((e = !0),
                                    console.warn(
                                        'Instance method `debug.destroy()` is deprecated and no longer does anything. It will be removed in the next major version of `debug`.'
                                    ))
                        }
                    })()),
                    (t.colors = [
                        '#0000CC',
                        '#0000FF',
                        '#0033CC',
                        '#0033FF',
                        '#0066CC',
                        '#0066FF',
                        '#0099CC',
                        '#0099FF',
                        '#00CC00',
                        '#00CC33',
                        '#00CC66',
                        '#00CC99',
                        '#00CCCC',
                        '#00CCFF',
                        '#3300CC',
                        '#3300FF',
                        '#3333CC',
                        '#3333FF',
                        '#3366CC',
                        '#3366FF',
                        '#3399CC',
                        '#3399FF',
                        '#33CC00',
                        '#33CC33',
                        '#33CC66',
                        '#33CC99',
                        '#33CCCC',
                        '#33CCFF',
                        '#6600CC',
                        '#6600FF',
                        '#6633CC',
                        '#6633FF',
                        '#66CC00',
                        '#66CC33',
                        '#9900CC',
                        '#9900FF',
                        '#9933CC',
                        '#9933FF',
                        '#99CC00',
                        '#99CC33',
                        '#CC0000',
                        '#CC0033',
                        '#CC0066',
                        '#CC0099',
                        '#CC00CC',
                        '#CC00FF',
                        '#CC3300',
                        '#CC3333',
                        '#CC3366',
                        '#CC3399',
                        '#CC33CC',
                        '#CC33FF',
                        '#CC6600',
                        '#CC6633',
                        '#CC9900',
                        '#CC9933',
                        '#CCCC00',
                        '#CCCC33',
                        '#FF0000',
                        '#FF0033',
                        '#FF0066',
                        '#FF0099',
                        '#FF00CC',
                        '#FF00FF',
                        '#FF3300',
                        '#FF3333',
                        '#FF3366',
                        '#FF3399',
                        '#FF33CC',
                        '#FF33FF',
                        '#FF6600',
                        '#FF6633',
                        '#FF9900',
                        '#FF9933',
                        '#FFCC00',
                        '#FFCC33'
                    ]),
                    (t.log = console.debug || console.log || (() => { })),
                    (e.exports = r(3279)(t))
                const { formatters: n } = e.exports
                n.j = function (e) {
                    try {
                        return JSON.stringify(e)
                    } catch (e) {
                        return '[UnexpectedJSONParseError]: ' + e.message
                    }
                }
            },
            3279: (e, t, r) => {
                e.exports = function (e) {
                    function t(e) {
                        let r,
                            i,
                            o,
                            s = null
                        function a(...e) {
                            if (!a.enabled) return
                            const n = a,
                                i = Number(new Date()),
                                o = i - (r || i)
                                ; (n.diff = o),
                                    (n.prev = r),
                                    (n.curr = i),
                                    (r = i),
                                    (e[0] = t.coerce(e[0])),
                                    'string' != typeof e[0] && e.unshift('%O')
                            let s = 0
                                ; (e[0] = e[0].replace(/%([a-zA-Z%])/g, (r, i) => {
                                    if ('%%' === r) return '%'
                                    s++
                                    const o = t.formatters[i]
                                    if ('function' == typeof o) {
                                        const t = e[s]
                                            ; (r = o.call(n, t)), e.splice(s, 1), s--
                                    }
                                    return r
                                })),
                                    t.formatArgs.call(n, e),
                                    (n.log || t.log).apply(n, e)
                        }
                        return (
                            (a.namespace = e),
                            (a.useColors = t.useColors()),
                            (a.color = t.selectColor(e)),
                            (a.extend = n),
                            (a.destroy = t.destroy),
                            Object.defineProperty(a, 'enabled', {
                                enumerable: !0,
                                configurable: !1,
                                get: () => (null !== s ? s : (i !== t.namespaces && ((i = t.namespaces), (o = t.enabled(e))), o)),
                                set: (e) => {
                                    s = e
                                }
                            }),
                            'function' == typeof t.init && t.init(a),
                            a
                        )
                    }
                    function n(e, r) {
                        const n = t(this.namespace + (void 0 === r ? ':' : r) + e)
                        return (n.log = this.log), n
                    }
                    function i(e) {
                        return e
                            .toString()
                            .substring(2, e.toString().length - 2)
                            .replace(/\.\*\?$/, '*')
                    }
                    return (
                        (t.debug = t),
                        (t.default = t),
                        (t.coerce = function (e) {
                            return e instanceof Error ? e.stack || e.message : e
                        }),
                        (t.disable = function () {
                            const e = [...t.names.map(i), ...t.skips.map(i).map((e) => '-' + e)].join(',')
                            return t.enable(''), e
                        }),
                        (t.enable = function (e) {
                            let r
                            t.save(e), (t.namespaces = e), (t.names = []), (t.skips = [])
                            const n = ('string' == typeof e ? e : '').split(/[\s,]+/),
                                i = n.length
                            for (r = 0; r < i; r++)
                                n[r] &&
                                    ('-' === (e = n[r].replace(/\*/g, '.*?'))[0]
                                        ? t.skips.push(new RegExp('^' + e.slice(1) + '$'))
                                        : t.names.push(new RegExp('^' + e + '$')))
                        }),
                        (t.enabled = function (e) {
                            if ('*' === e[e.length - 1]) return !0
                            let r, n
                            for (r = 0, n = t.skips.length; r < n; r++) if (t.skips[r].test(e)) return !1
                            for (r = 0, n = t.names.length; r < n; r++) if (t.names[r].test(e)) return !0
                            return !1
                        }),
                        (t.humanize = r(6847)),
                        (t.destroy = function () {
                            console.warn(
                                'Instance method `debug.destroy()` is deprecated and no longer does anything. It will be removed in the next major version of `debug`.'
                            )
                        }),
                        Object.keys(e).forEach((r) => {
                            t[r] = e[r]
                        }),
                        (t.names = []),
                        (t.skips = []),
                        (t.formatters = {}),
                        (t.selectColor = function (e) {
                            let r = 0
                            for (let t = 0; t < e.length; t++) (r = (r << 5) - r + e.charCodeAt(t)), (r |= 0)
                            return t.colors[Math.abs(r) % t.colors.length]
                        }),
                        t.enable(t.load()),
                        t
                    )
                }
            },
            3563: (e, t, r) => {
                var n
                !(function (i) {
                    var o = Object.hasOwnProperty,
                        s = Array.isArray
                            ? Array.isArray
                            : function (e) {
                                return '[object Array]' === Object.prototype.toString.call(e)
                            },
                        a = 'object' == typeof process && 'function' == typeof process.nextTick,
                        u = 'function' == typeof Symbol,
                        c = 'object' == typeof Reflect,
                        l = 'function' == typeof setImmediate ? setImmediate : setTimeout,
                        d = u
                            ? c && 'function' == typeof Reflect.ownKeys
                                ? Reflect.ownKeys
                                : function (e) {
                                    var t = Object.getOwnPropertyNames(e)
                                    return t.push.apply(t, Object.getOwnPropertySymbols(e)), t
                                }
                            : Object.keys
                    function f() {
                        ; (this._events = {}), this._conf && p.call(this, this._conf)
                    }
                    function p(e) {
                        e &&
                            ((this._conf = e),
                                e.delimiter && (this.delimiter = e.delimiter),
                                e.maxListeners !== i && (this._maxListeners = e.maxListeners),
                                e.wildcard && (this.wildcard = e.wildcard),
                                e.newListener && (this._newListener = e.newListener),
                                e.removeListener && (this._removeListener = e.removeListener),
                                e.verboseMemoryLeak && (this.verboseMemoryLeak = e.verboseMemoryLeak),
                                e.ignoreErrors && (this.ignoreErrors = e.ignoreErrors),
                                this.wildcard && (this.listenerTree = {}))
                    }
                    function m(e, t) {
                        var r =
                            '(node) warning: possible EventEmitter memory leak detected. ' +
                            e +
                            ' listeners added. Use emitter.setMaxListeners() to increase limit.'
                        if (
                            (this.verboseMemoryLeak && (r += ' Event name: ' + t + '.'),
                                'undefined' != typeof process && process.emitWarning)
                        ) {
                            var n = new Error(r)
                                ; (n.name = 'MaxListenersExceededWarning'), (n.emitter = this), (n.count = e), process.emitWarning(n)
                        } else console.error(r), console.trace && console.trace()
                    }
                    var g = function (e, t, r) {
                        var n = arguments.length
                        switch (n) {
                            case 0:
                                return []
                            case 1:
                                return [e]
                            case 2:
                                return [e, t]
                            case 3:
                                return [e, t, r]
                            default:
                                for (var i = new Array(n); n--;) i[n] = arguments[n]
                                return i
                        }
                    }
                    function h(e, t) {
                        for (var r = {}, n = e.length, o = t ? t.length : 0, s = 0; s < n; s++) r[e[s]] = s < o ? t[s] : i
                        return r
                    }
                    function y(e, t, r) {
                        var n, i
                        if (
                            ((this._emitter = e),
                                (this._target = t),
                                (this._listeners = {}),
                                (this._listenersCount = 0),
                                (r.on || r.off) && ((n = r.on), (i = r.off)),
                                t.addEventListener
                                    ? ((n = t.addEventListener), (i = t.removeEventListener))
                                    : t.addListener
                                        ? ((n = t.addListener), (i = t.removeListener))
                                        : t.on && ((n = t.on), (i = t.off)),
                                !n && !i)
                        )
                            throw Error('target does not implement any known event API')
                        if ('function' != typeof n) throw TypeError('on method must be a function')
                        if ('function' != typeof i) throw TypeError('off method must be a function')
                            ; (this._on = n), (this._off = i)
                        var o = e._observers
                        o ? o.push(this) : (e._observers = [this])
                    }
                    function b(e, t, r, n) {
                        var s = Object.assign({}, t)
                        if (!e) return s
                        if ('object' != typeof e) throw TypeError('options must be an object')
                        var a,
                            u,
                            c,
                            l = Object.keys(e),
                            d = l.length
                        function f(e) {
                            throw Error('Invalid "' + a + '" option value' + (e ? '. Reason: ' + e : ''))
                        }
                        for (var p = 0; p < d; p++) {
                            if (((a = l[p]), !n && !o.call(t, a))) throw Error('Unknown "' + a + '" option')
                                ; (u = e[a]) !== i && ((c = r[a]), (s[a] = c ? c(u, f) : u))
                        }
                        return s
                    }
                    function v(e, t) {
                        return ('function' == typeof e && e.hasOwnProperty('prototype')) || t('value must be a constructor'), e
                    }
                    function _(e) {
                        var t = 'value must be type of ' + e.join('|'),
                            r = e.length,
                            n = e[0],
                            i = e[1]
                        return 1 === r
                            ? function (e, r) {
                                if (typeof e === n) return e
                                r(t)
                            }
                            : 2 === r
                                ? function (e, r) {
                                    var o = typeof e
                                    if (o === n || o === i) return e
                                    r(t)
                                }
                                : function (n, i) {
                                    for (var o = typeof n, s = r; s-- > 0;) if (o === e[s]) return n
                                    i(t)
                                }
                    }
                    Object.assign(y.prototype, {
                        subscribe: function (e, t, r) {
                            var n = this,
                                i = this._target,
                                o = this._emitter,
                                s = this._listeners,
                                a = function () {
                                    var n = g.apply(null, arguments),
                                        s = { data: n, name: t, original: e }
                                    if (r) {
                                        var a = r.call(i, s)
                                        !1 !== a && o.emit.apply(o, [s.name].concat(n))
                                    } else o.emit.apply(o, [t].concat(n))
                                }
                            if (s[e]) throw Error("Event '" + e + "' is already listening")
                            this._listenersCount++,
                                o._newListener && o._removeListener && !n._onNewListener
                                    ? ((this._onNewListener = function (r) {
                                        r === t && null === s[e] && ((s[e] = a), n._on.call(i, e, a))
                                    }),
                                        o.on('newListener', this._onNewListener),
                                        (this._onRemoveListener = function (r) {
                                            r === t && !o.hasListeners(r) && s[e] && ((s[e] = null), n._off.call(i, e, a))
                                        }),
                                        (s[e] = null),
                                        o.on('removeListener', this._onRemoveListener))
                                    : ((s[e] = a), n._on.call(i, e, a))
                        },
                        unsubscribe: function (e) {
                            var t,
                                r,
                                n,
                                i = this,
                                o = this._listeners,
                                s = this._emitter,
                                a = this._off,
                                u = this._target
                            if (e && 'string' != typeof e) throw TypeError('event must be a string')
                            function c() {
                                i._onNewListener &&
                                    (s.off('newListener', i._onNewListener),
                                        s.off('removeListener', i._onRemoveListener),
                                        (i._onNewListener = null),
                                        (i._onRemoveListener = null))
                                var e = O.call(s, i)
                                s._observers.splice(e, 1)
                            }
                            if (e) {
                                if (!(t = o[e])) return
                                a.call(u, e, t), delete o[e], --this._listenersCount || c()
                            } else {
                                for (n = (r = d(o)).length; n-- > 0;) (e = r[n]), a.call(u, e, o[e])
                                    ; (this._listeners = {}), (this._listenersCount = 0), c()
                            }
                        }
                    })
                    var M = _(['function']),
                        P = _(['object', 'function'])
                    function w(e, t, r) {
                        var n,
                            i,
                            o,
                            s = 0,
                            a = new e(function (u, c, l) {
                                function d() {
                                    i && (i = null), s && (clearTimeout(s), (s = 0))
                                }
                                ; (r = b(
                                    r,
                                    { timeout: 0, overload: !1 },
                                    {
                                        timeout: function (e, t) {
                                            return (
                                                ('number' != typeof (e *= 1) || e < 0 || !Number.isFinite(e)) &&
                                                t('timeout must be a positive number'),
                                                e
                                            )
                                        }
                                    }
                                )),
                                    (n = !r.overload && 'function' == typeof e.prototype.cancel && 'function' == typeof l)
                                var f = function (e) {
                                    d(), u(e)
                                },
                                    p = function (e) {
                                        d(), c(e)
                                    }
                                n
                                    ? t(f, p, l)
                                    : ((i = [
                                        function (e) {
                                            p(e || Error('canceled'))
                                        }
                                    ]),
                                        t(f, p, function (e) {
                                            if (o) throw Error('Unable to subscribe on cancel event asynchronously')
                                            if ('function' != typeof e) throw TypeError('onCancel callback must be a function')
                                            i.push(e)
                                        }),
                                        (o = !0)),
                                    r.timeout > 0 &&
                                    (s = setTimeout(function () {
                                        var e = Error('timeout')
                                            ; (e.code = 'ETIMEDOUT'), (s = 0), a.cancel(e), c(e)
                                    }, r.timeout))
                            })
                        return (
                            n ||
                            (a.cancel = function (e) {
                                if (i) {
                                    for (var t = i.length, r = 1; r < t; r++) i[r](e)
                                    i[0](e), (i = null)
                                }
                            }),
                            a
                        )
                    }
                    function O(e) {
                        var t = this._observers
                        if (!t) return -1
                        for (var r = t.length, n = 0; n < r; n++) if (t[n]._target === e) return n
                        return -1
                    }
                    function j(e, t, r, n, i) {
                        if (!r) return null
                        if (0 === n) {
                            var o = typeof t
                            if ('string' === o) {
                                var s,
                                    a,
                                    u = 0,
                                    c = 0,
                                    l = this.delimiter,
                                    f = l.length
                                if (-1 !== (a = t.indexOf(l))) {
                                    s = new Array(5)
                                    do {
                                        ; (s[u++] = t.slice(c, a)), (c = a + f)
                                    } while (-1 !== (a = t.indexOf(l, c)))
                                        ; (s[u++] = t.slice(c)), (t = s), (i = u)
                                } else (t = [t]), (i = 1)
                            } else 'object' === o ? (i = t.length) : ((t = [t]), (i = 1))
                        }
                        var p,
                            m,
                            g,
                            h,
                            y,
                            b,
                            v,
                            _ = null,
                            M = t[n],
                            P = t[n + 1]
                        if (n === i)
                            r._listeners &&
                                ('function' == typeof r._listeners
                                    ? (e && e.push(r._listeners), (_ = [r]))
                                    : (e && e.push.apply(e, r._listeners), (_ = [r])))
                        else {
                            if ('*' === M) {
                                for (a = (b = d(r)).length; a-- > 0;)
                                    '_listeners' !== (p = b[a]) && (v = j(e, t, r[p], n + 1, i)) && (_ ? _.push.apply(_, v) : (_ = v))
                                return _
                            }
                            if ('**' === M) {
                                for (
                                    (y = n + 1 === i || (n + 2 === i && '*' === P)) && r._listeners && (_ = j(e, t, r, i, i)),
                                    a = (b = d(r)).length;
                                    a-- > 0;

                                )
                                    '_listeners' !== (p = b[a]) &&
                                        ('*' === p || '**' === p
                                            ? (r[p]._listeners && !y && (v = j(e, t, r[p], i, i)) && (_ ? _.push.apply(_, v) : (_ = v)),
                                                (v = j(e, t, r[p], n, i)))
                                            : (v = j(e, t, r[p], p === P ? n + 2 : n, i)),
                                            v && (_ ? _.push.apply(_, v) : (_ = v)))
                                return _
                            }
                            r[M] && (_ = j(e, t, r[M], n + 1, i))
                        }
                        if (((m = r['*']) && j(e, t, m, n + 1, i), (g = r['**'])))
                            if (n < i)
                                for (g._listeners && j(e, t, g, i, i), a = (b = d(g)).length; a-- > 0;)
                                    '_listeners' !== (p = b[a]) &&
                                        (p === P
                                            ? j(e, t, g[p], n + 2, i)
                                            : p === M
                                                ? j(e, t, g[p], n + 1, i)
                                                : (((h = {})[p] = g[p]), j(e, t, { '**': h }, n + 1, i)))
                            else g._listeners ? j(e, t, g, i, i) : g['*'] && g['*']._listeners && j(e, t, g['*'], i, i)
                        return _
                    }
                    function x(e, t, r) {
                        var n,
                            i,
                            o = 0,
                            s = 0,
                            a = this.delimiter,
                            u = a.length
                        if ('string' == typeof e)
                            if (-1 !== (n = e.indexOf(a))) {
                                i = new Array(5)
                                do {
                                    ; (i[o++] = e.slice(s, n)), (s = n + u)
                                } while (-1 !== (n = e.indexOf(a, s)))
                                i[o++] = e.slice(s)
                            } else (i = [e]), (o = 1)
                        else (i = e), (o = e.length)
                        if (o > 1) for (n = 0; n + 1 < o; n++) if ('**' === i[n] && '**' === i[n + 1]) return
                        var c,
                            l = this.listenerTree
                        for (n = 0; n < o; n++)
                            if (((l = l[(c = i[n])] || (l[c] = {})), n === o - 1))
                                return (
                                    l._listeners
                                        ? ('function' == typeof l._listeners && (l._listeners = [l._listeners]),
                                            r ? l._listeners.unshift(t) : l._listeners.push(t),
                                            !l._listeners.warned &&
                                            this._maxListeners > 0 &&
                                            l._listeners.length > this._maxListeners &&
                                            ((l._listeners.warned = !0), m.call(this, l._listeners.length, c)))
                                        : (l._listeners = t),
                                    !0
                                )
                        return !0
                    }
                    function C(e, t, r, n) {
                        for (var i, o, s, a, u = d(e), c = u.length, l = e._listeners; c-- > 0;)
                            (i = e[(o = u[c])]),
                                (s = '_listeners' === o ? r : r ? r.concat(o) : [o]),
                                (a = n || 'symbol' == typeof o),
                                l && t.push(a ? s : s.join(this.delimiter)),
                                'object' == typeof i && C.call(this, i, t, s, a)
                        return t
                    }
                    function S(e) {
                        for (var t, r, n, i = d(e), o = i.length; o-- > 0;)
                            (t = e[(r = i[o])]) && ((n = !0), '_listeners' === r || S(t) || delete e[r])
                        return n
                    }
                    function I(e, t, r) {
                        ; (this.emitter = e), (this.event = t), (this.listener = r)
                    }
                    function E(e, t, r) {
                        if (!0 === r) o = !0
                        else if (!1 === r) n = !0
                        else {
                            if (!r || 'object' != typeof r) throw TypeError('options should be an object or true')
                            var n = r.async,
                                o = r.promisify,
                                s = r.nextTick,
                                u = r.objectify
                        }
                        if (n || s || o) {
                            var c = t,
                                d = t._origin || t
                            if (s && !a) throw Error('process.nextTick is not supported')
                            o === i && (o = 'AsyncFunction' === t.constructor.name),
                                (t = function () {
                                    var e = arguments,
                                        t = this,
                                        r = this.event
                                    return o
                                        ? s
                                            ? Promise.resolve()
                                            : new Promise(function (e) {
                                                l(e)
                                            }).then(function () {
                                                return (t.event = r), c.apply(t, e)
                                            })
                                        : (s ? process.nextTick : l)(function () {
                                            ; (t.event = r), c.apply(t, e)
                                        })
                                }),
                                (t._async = !0),
                                (t._origin = d)
                        }
                        return [t, u ? new I(this, e, t) : this]
                    }
                    function k(e) {
                        ; (this._events = {}),
                            (this._newListener = !1),
                            (this._removeListener = !1),
                            (this.verboseMemoryLeak = !1),
                            p.call(this, e)
                    }
                    ; (I.prototype.off = function () {
                        return this.emitter.off(this.event, this.listener), this
                    }),
                        (k.EventEmitter2 = k),
                        (k.prototype.listenTo = function (e, t, r) {
                            if ('object' != typeof e) throw TypeError('target musts be an object')
                            var n = this
                            function o(t) {
                                if ('object' != typeof t) throw TypeError('events must be an object')
                                var i,
                                    o = r.reducers,
                                    s = O.call(n, e)
                                i = -1 === s ? new y(n, e, r) : n._observers[s]
                                for (var a, u = d(t), c = u.length, l = 'function' == typeof o, f = 0; f < c; f++)
                                    (a = u[f]), i.subscribe(a, t[a] || a, l ? o : o && o[a])
                            }
                            return (
                                (r = b(r, { on: i, off: i, reducers: i }, { on: M, off: M, reducers: P })),
                                s(t) ? o(h(t)) : o('string' == typeof t ? h(t.split(/\s+/)) : t),
                                this
                            )
                        }),
                        (k.prototype.stopListeningTo = function (e, t) {
                            var r = this._observers
                            if (!r) return !1
                            var n,
                                i = r.length,
                                o = !1
                            if (e && 'object' != typeof e) throw TypeError('target should be an object')
                            for (; i-- > 0;) (n = r[i]), (e && n._target !== e) || (n.unsubscribe(t), (o = !0))
                            return o
                        }),
                        (k.prototype.delimiter = '.'),
                        (k.prototype.setMaxListeners = function (e) {
                            e !== i && ((this._maxListeners = e), this._conf || (this._conf = {}), (this._conf.maxListeners = e))
                        }),
                        (k.prototype.getMaxListeners = function () {
                            return this._maxListeners
                        }),
                        (k.prototype.event = ''),
                        (k.prototype.once = function (e, t, r) {
                            return this._once(e, t, !1, r)
                        }),
                        (k.prototype.prependOnceListener = function (e, t, r) {
                            return this._once(e, t, !0, r)
                        }),
                        (k.prototype._once = function (e, t, r, n) {
                            return this._many(e, 1, t, r, n)
                        }),
                        (k.prototype.many = function (e, t, r, n) {
                            return this._many(e, t, r, !1, n)
                        }),
                        (k.prototype.prependMany = function (e, t, r, n) {
                            return this._many(e, t, r, !0, n)
                        }),
                        (k.prototype._many = function (e, t, r, n, i) {
                            var o = this
                            if ('function' != typeof r) throw new Error('many only accepts instances of Function')
                            function s() {
                                return 0 == --t && o.off(e, s), r.apply(this, arguments)
                            }
                            return (s._origin = r), this._on(e, s, n, i)
                        }),
                        (k.prototype.emit = function () {
                            if (!this._events && !this._all) return !1
                            this._events || f.call(this)
                            var e,
                                t,
                                r,
                                n,
                                i,
                                o,
                                s = arguments[0],
                                a = this.wildcard
                            if ('newListener' === s && !this._newListener && !this._events.newListener) return !1
                            if (a && ((e = s), 'newListener' !== s && 'removeListener' !== s && 'object' == typeof s)) {
                                if (((r = s.length), u))
                                    for (n = 0; n < r; n++)
                                        if ('symbol' == typeof s[n]) {
                                            o = !0
                                            break
                                        }
                                o || (s = s.join(this.delimiter))
                            }
                            var c,
                                l = arguments.length
                            if (this._all && this._all.length)
                                for (n = 0, r = (c = this._all.slice()).length; n < r; n++)
                                    switch (((this.event = s), l)) {
                                        case 1:
                                            c[n].call(this, s)
                                            break
                                        case 2:
                                            c[n].call(this, s, arguments[1])
                                            break
                                        case 3:
                                            c[n].call(this, s, arguments[1], arguments[2])
                                            break
                                        default:
                                            c[n].apply(this, arguments)
                                    }
                            if (a) (c = []), j.call(this, c, e, this.listenerTree, 0, r)
                            else {
                                if ('function' == typeof (c = this._events[s])) {
                                    switch (((this.event = s), l)) {
                                        case 1:
                                            c.call(this)
                                            break
                                        case 2:
                                            c.call(this, arguments[1])
                                            break
                                        case 3:
                                            c.call(this, arguments[1], arguments[2])
                                            break
                                        default:
                                            for (t = new Array(l - 1), i = 1; i < l; i++) t[i - 1] = arguments[i]
                                            c.apply(this, t)
                                    }
                                    return !0
                                }
                                c && (c = c.slice())
                            }
                            if (c && c.length) {
                                if (l > 3) for (t = new Array(l - 1), i = 1; i < l; i++) t[i - 1] = arguments[i]
                                for (n = 0, r = c.length; n < r; n++)
                                    switch (((this.event = s), l)) {
                                        case 1:
                                            c[n].call(this)
                                            break
                                        case 2:
                                            c[n].call(this, arguments[1])
                                            break
                                        case 3:
                                            c[n].call(this, arguments[1], arguments[2])
                                            break
                                        default:
                                            c[n].apply(this, t)
                                    }
                                return !0
                            }
                            if (!this.ignoreErrors && !this._all && 'error' === s)
                                throw arguments[1] instanceof Error ? arguments[1] : new Error("Uncaught, unspecified 'error' event.")
                            return !!this._all
                        }),
                        (k.prototype.emitAsync = function () {
                            if (!this._events && !this._all) return !1
                            this._events || f.call(this)
                            var e,
                                t,
                                r,
                                n,
                                i,
                                o,
                                s = arguments[0],
                                a = this.wildcard
                            if ('newListener' === s && !this._newListener && !this._events.newListener) return Promise.resolve([!1])
                            if (a && ((e = s), 'newListener' !== s && 'removeListener' !== s && 'object' == typeof s)) {
                                if (((n = s.length), u))
                                    for (i = 0; i < n; i++)
                                        if ('symbol' == typeof s[i]) {
                                            t = !0
                                            break
                                        }
                                t || (s = s.join(this.delimiter))
                            }
                            var c,
                                l = [],
                                d = arguments.length
                            if (this._all)
                                for (i = 0, n = this._all.length; i < n; i++)
                                    switch (((this.event = s), d)) {
                                        case 1:
                                            l.push(this._all[i].call(this, s))
                                            break
                                        case 2:
                                            l.push(this._all[i].call(this, s, arguments[1]))
                                            break
                                        case 3:
                                            l.push(this._all[i].call(this, s, arguments[1], arguments[2]))
                                            break
                                        default:
                                            l.push(this._all[i].apply(this, arguments))
                                    }
                            if (
                                (a ? ((c = []), j.call(this, c, e, this.listenerTree, 0)) : (c = this._events[s]),
                                    'function' == typeof c)
                            )
                                switch (((this.event = s), d)) {
                                    case 1:
                                        l.push(c.call(this))
                                        break
                                    case 2:
                                        l.push(c.call(this, arguments[1]))
                                        break
                                    case 3:
                                        l.push(c.call(this, arguments[1], arguments[2]))
                                        break
                                    default:
                                        for (r = new Array(d - 1), o = 1; o < d; o++) r[o - 1] = arguments[o]
                                        l.push(c.apply(this, r))
                                }
                            else if (c && c.length) {
                                if (((c = c.slice()), d > 3)) for (r = new Array(d - 1), o = 1; o < d; o++) r[o - 1] = arguments[o]
                                for (i = 0, n = c.length; i < n; i++)
                                    switch (((this.event = s), d)) {
                                        case 1:
                                            l.push(c[i].call(this))
                                            break
                                        case 2:
                                            l.push(c[i].call(this, arguments[1]))
                                            break
                                        case 3:
                                            l.push(c[i].call(this, arguments[1], arguments[2]))
                                            break
                                        default:
                                            l.push(c[i].apply(this, r))
                                    }
                            } else if (!this.ignoreErrors && !this._all && 'error' === s)
                                return arguments[1] instanceof Error
                                    ? Promise.reject(arguments[1])
                                    : Promise.reject("Uncaught, unspecified 'error' event.")
                            return Promise.all(l)
                        }),
                        (k.prototype.on = function (e, t, r) {
                            return this._on(e, t, !1, r)
                        }),
                        (k.prototype.prependListener = function (e, t, r) {
                            return this._on(e, t, !0, r)
                        }),
                        (k.prototype.onAny = function (e) {
                            return this._onAny(e, !1)
                        }),
                        (k.prototype.prependAny = function (e) {
                            return this._onAny(e, !0)
                        }),
                        (k.prototype.addListener = k.prototype.on),
                        (k.prototype._onAny = function (e, t) {
                            if ('function' != typeof e) throw new Error('onAny only accepts instances of Function')
                            return this._all || (this._all = []), t ? this._all.unshift(e) : this._all.push(e), this
                        }),
                        (k.prototype._on = function (e, t, r, n) {
                            if ('function' == typeof e) return this._onAny(e, t), this
                            if ('function' != typeof t) throw new Error('on only accepts instances of Function')
                            this._events || f.call(this)
                            var o,
                                s = this
                            return (
                                n !== i && ((t = (o = E.call(this, e, t, n))[0]), (s = o[1])),
                                this._newListener && this.emit('newListener', e, t),
                                this.wildcard
                                    ? (x.call(this, e, t, r), s)
                                    : (this._events[e]
                                        ? ('function' == typeof this._events[e] && (this._events[e] = [this._events[e]]),
                                            r ? this._events[e].unshift(t) : this._events[e].push(t),
                                            !this._events[e].warned &&
                                            this._maxListeners > 0 &&
                                            this._events[e].length > this._maxListeners &&
                                            ((this._events[e].warned = !0), m.call(this, this._events[e].length, e)))
                                        : (this._events[e] = t),
                                        s)
                            )
                        }),
                        (k.prototype.off = function (e, t) {
                            if ('function' != typeof t) throw new Error('removeListener only takes instances of Function')
                            var r,
                                n = []
                            if (this.wildcard) {
                                var i = 'string' == typeof e ? e.split(this.delimiter) : e.slice()
                                if (!(n = j.call(this, null, i, this.listenerTree, 0))) return this
                            } else {
                                if (!this._events[e]) return this
                                    ; (r = this._events[e]), n.push({ _listeners: r })
                            }
                            for (var o = 0; o < n.length; o++) {
                                var a = n[o]
                                if (((r = a._listeners), s(r))) {
                                    for (var u = -1, c = 0, l = r.length; c < l; c++)
                                        if (
                                            r[c] === t ||
                                            (r[c].listener && r[c].listener === t) ||
                                            (r[c]._origin && r[c]._origin === t)
                                        ) {
                                            u = c
                                            break
                                        }
                                    if (u < 0) continue
                                    return (
                                        this.wildcard ? a._listeners.splice(u, 1) : this._events[e].splice(u, 1),
                                        0 === r.length && (this.wildcard ? delete a._listeners : delete this._events[e]),
                                        this._removeListener && this.emit('removeListener', e, t),
                                        this
                                    )
                                }
                                ; (r === t || (r.listener && r.listener === t) || (r._origin && r._origin === t)) &&
                                    (this.wildcard ? delete a._listeners : delete this._events[e],
                                        this._removeListener && this.emit('removeListener', e, t))
                            }
                            return this.listenerTree && S(this.listenerTree), this
                        }),
                        (k.prototype.offAny = function (e) {
                            var t,
                                r = 0,
                                n = 0
                            if (e && this._all && this._all.length > 0) {
                                for (r = 0, n = (t = this._all).length; r < n; r++)
                                    if (e === t[r])
                                        return t.splice(r, 1), this._removeListener && this.emit('removeListenerAny', e), this
                            } else {
                                if (((t = this._all), this._removeListener))
                                    for (r = 0, n = t.length; r < n; r++) this.emit('removeListenerAny', t[r])
                                this._all = []
                            }
                            return this
                        }),
                        (k.prototype.removeListener = k.prototype.off),
                        (k.prototype.removeAllListeners = function (e) {
                            if (e === i) return !this._events || f.call(this), this
                            if (this.wildcard) {
                                var t,
                                    r = j.call(this, null, e, this.listenerTree, 0)
                                if (!r) return this
                                for (t = 0; t < r.length; t++) r[t]._listeners = null
                                this.listenerTree && S(this.listenerTree)
                            } else this._events && (this._events[e] = null)
                            return this
                        }),
                        (k.prototype.listeners = function (e) {
                            var t,
                                r,
                                n,
                                o,
                                s,
                                a = this._events
                            if (e === i) {
                                if (this.wildcard) throw Error('event name required for wildcard emitter')
                                if (!a) return []
                                for (o = (t = d(a)).length, n = []; o-- > 0;)
                                    'function' == typeof (r = a[t[o]]) ? n.push(r) : n.push.apply(n, r)
                                return n
                            }
                            if (this.wildcard) {
                                if (!(s = this.listenerTree)) return []
                                var u = [],
                                    c = 'string' == typeof e ? e.split(this.delimiter) : e.slice()
                                return j.call(this, u, c, s, 0), u
                            }
                            return a && (r = a[e]) ? ('function' == typeof r ? [r] : r) : []
                        }),
                        (k.prototype.eventNames = function (e) {
                            var t = this._events
                            return this.wildcard ? C.call(this, this.listenerTree, [], null, e) : t ? d(t) : []
                        }),
                        (k.prototype.listenerCount = function (e) {
                            return this.listeners(e).length
                        }),
                        (k.prototype.hasListeners = function (e) {
                            if (this.wildcard) {
                                var t = [],
                                    r = 'string' == typeof e ? e.split(this.delimiter) : e.slice()
                                return j.call(this, t, r, this.listenerTree, 0), t.length > 0
                            }
                            var n = this._events,
                                o = this._all
                            return !!((o && o.length) || (n && (e === i ? d(n).length : n[e])))
                        }),
                        (k.prototype.listenersAny = function () {
                            return this._all ? this._all : []
                        }),
                        (k.prototype.waitFor = function (e, t) {
                            var r = this,
                                n = typeof t
                            return (
                                'number' === n ? (t = { timeout: t }) : 'function' === n && (t = { filter: t }),
                                w(
                                    (t = b(
                                        t,
                                        { timeout: 0, filter: i, handleError: !1, Promise, overload: !1 },
                                        { filter: M, Promise: v }
                                    )).Promise,
                                    function (n, i, o) {
                                        function s() {
                                            var o = t.filter
                                            if (!o || o.apply(r, arguments))
                                                if ((r.off(e, s), t.handleError)) {
                                                    var a = arguments[0]
                                                    a ? i(a) : n(g.apply(null, arguments).slice(1))
                                                } else n(g.apply(null, arguments))
                                        }
                                        o(function () {
                                            r.off(e, s)
                                        }),
                                            r._on(e, s, !1)
                                    },
                                    { timeout: t.timeout, overload: t.overload }
                                )
                            )
                        })
                    var T = k.prototype
                    Object.defineProperties(k, {
                        defaultMaxListeners: {
                            get: function () {
                                return T._maxListeners
                            },
                            set: function (e) {
                                if ('number' != typeof e || e < 0 || Number.isNaN(e))
                                    throw TypeError('n must be a non-negative number')
                                T._maxListeners = e
                            },
                            enumerable: !0
                        },
                        once: {
                            value: function (e, t, r) {
                                return w(
                                    (r = b(r, { Promise, timeout: 0, overload: !1 }, { Promise: v })).Promise,
                                    function (r, n, i) {
                                        var o
                                        if ('function' == typeof e.addEventListener)
                                            return (
                                                (o = function () {
                                                    r(g.apply(null, arguments))
                                                }),
                                                i(function () {
                                                    e.removeEventListener(t, o)
                                                }),
                                                void e.addEventListener(t, o, { once: !0 })
                                            )
                                        var s,
                                            a = function () {
                                                s && e.removeListener('error', s), r(g.apply(null, arguments))
                                            }
                                        'error' !== t &&
                                            ((s = function (r) {
                                                e.removeListener(t, a), n(r)
                                            }),
                                                e.once('error', s)),
                                            i(function () {
                                                s && e.removeListener('error', s), e.removeListener(t, a)
                                            }),
                                            e.once(t, a)
                                    },
                                    { timeout: r.timeout, overload: r.overload }
                                )
                            },
                            writable: !0,
                            configurable: !0
                        }
                    }),
                        Object.defineProperties(T, {
                            _maxListeners: { value: 10, writable: !0, configurable: !0 },
                            _observers: { value: null, writable: !0, configurable: !0 }
                        }),
                        (n = function () {
                            return k
                        }.call(t, r, t, e)) === i || (e.exports = n)
                })()
            },
            9172: (module, __unused_webpack_exports, __webpack_require__) => {
                'use strict'
                var Buffer = __webpack_require__(692).lW
                const Token = __webpack_require__(7744),
                    strtok3 = __webpack_require__(2055),
                    { stringToBytes, tarHeaderChecksumMatches, uint32SyncSafeToken } = __webpack_require__(6622),
                    supported = __webpack_require__(2453),
                    minimumBytes = 4100
                async function fromStream(e) {
                    const t = await strtok3.fromStream(e)
                    try {
                        return await fromTokenizer(t)
                    } finally {
                        await t.close()
                    }
                }
                async function fromBuffer(e) {
                    if (!(e instanceof Uint8Array || e instanceof ArrayBuffer || Buffer.isBuffer(e)))
                        throw new TypeError(
                            `Expected the \`input\` argument to be of type \`Uint8Array\` or \`Buffer\` or \`ArrayBuffer\`, got \`${typeof e}\``
                        )
                    const t = e instanceof Buffer ? e : Buffer.from(e)
                    if (t && t.length > 1) return fromTokenizer(strtok3.fromBuffer(t))
                }
                function _check(e, t, r) {
                    r = { offset: 0, ...r }
                    for (const [n, i] of t.entries())
                        if (r.mask) {
                            if (i !== (r.mask[n] & e[n + r.offset])) return !1
                        } else if (i !== e[n + r.offset]) return !1
                    return !0
                }
                async function fromTokenizer(e) {
                    try {
                        return _fromTokenizer(e)
                    } catch (e) {
                        if (!(e instanceof strtok3.EndOfStreamError)) throw e
                    }
                }
                async function _fromTokenizer(e) {
                    let t = Buffer.alloc(minimumBytes)
                    const r = (e, r) => _check(t, e, r),
                        n = (e, t) => r(stringToBytes(e), t)
                    if (
                        (e.fileInfo.size || (e.fileInfo.size = Number.MAX_SAFE_INTEGER),
                            await e.peekBuffer(t, { length: 12, mayBeLess: !0 }),
                            r([66, 77]))
                    )
                        return { ext: 'bmp', mime: 'image/bmp' }
                    if (r([11, 119])) return { ext: 'ac3', mime: 'audio/vnd.dolby.dd-raw' }
                    if (r([120, 1])) return { ext: 'dmg', mime: 'application/x-apple-diskimage' }
                    if (r([77, 90])) return { ext: 'exe', mime: 'application/x-msdownload' }
                    if (r([37, 33]))
                        return (
                            await e.peekBuffer(t, { length: 24, mayBeLess: !0 }),
                            n('PS-Adobe-', { offset: 2 }) && n(' EPSF-', { offset: 14 })
                                ? { ext: 'eps', mime: 'application/eps' }
                                : { ext: 'ps', mime: 'application/postscript' }
                        )
                    if (r([31, 160]) || r([31, 157])) return { ext: 'Z', mime: 'application/x-compress' }
                    if (r([255, 216, 255])) return { ext: 'jpg', mime: 'image/jpeg' }
                    if (r([73, 73, 188])) return { ext: 'jxr', mime: 'image/vnd.ms-photo' }
                    if (r([31, 139, 8])) return { ext: 'gz', mime: 'application/gzip' }
                    if (r([66, 90, 104])) return { ext: 'bz2', mime: 'application/x-bzip2' }
                    if (n('ID3')) {
                        await e.ignore(6)
                        const i = await e.readToken(uint32SyncSafeToken)
                        return e.position + i > e.fileInfo.size
                            ? { ext: 'mp3', mime: 'audio/mpeg' }
                            : (await e.ignore(i), fromTokenizer(e))
                    }
                    if (n('MP+')) return { ext: 'mpc', mime: 'audio/x-musepack' }
                    if ((67 === t[0] || 70 === t[0]) && r([87, 83], { offset: 1 }))
                        return { ext: 'swf', mime: 'application/x-shockwave-flash' }
                    if (r([71, 73, 70])) return { ext: 'gif', mime: 'image/gif' }
                    if (n('FLIF')) return { ext: 'flif', mime: 'image/flif' }
                    if (n('8BPS')) return { ext: 'psd', mime: 'image/vnd.adobe.photoshop' }
                    if (n('WEBP', { offset: 8 })) return { ext: 'webp', mime: 'image/webp' }
                    if (n('MPCK')) return { ext: 'mpc', mime: 'audio/x-musepack' }
                    if (n('FORM')) return { ext: 'aif', mime: 'audio/aiff' }
                    if (n('icns', { offset: 0 })) return { ext: 'icns', mime: 'image/icns' }
                    if (r([80, 75, 3, 4])) {
                        try {
                            for (; e.position + 30 < e.fileInfo.size;) {
                                await e.readBuffer(t, { length: 30 })
                                const o = {
                                    compressedSize: t.readUInt32LE(18),
                                    uncompressedSize: t.readUInt32LE(22),
                                    filenameLength: t.readUInt16LE(26),
                                    extraFieldLength: t.readUInt16LE(28)
                                }
                                if (
                                    ((o.filename = await e.readToken(new Token.StringType(o.filenameLength, 'utf-8'))),
                                        await e.ignore(o.extraFieldLength),
                                        'META-INF/mozilla.rsa' === o.filename)
                                )
                                    return { ext: 'xpi', mime: 'application/x-xpinstall' }
                                if (o.filename.endsWith('.rels') || o.filename.endsWith('.xml'))
                                    switch (o.filename.split('/')[0]) {
                                        case '_rels':
                                        default:
                                            break
                                        case 'word':
                                            return {
                                                ext: 'docx',
                                                mime: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document'
                                            }
                                        case 'ppt':
                                            return {
                                                ext: 'pptx',
                                                mime: 'application/vnd.openxmlformats-officedocument.presentationml.presentation'
                                            }
                                        case 'xl':
                                            return {
                                                ext: 'xlsx',
                                                mime: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
                                            }
                                    }
                                if (o.filename.startsWith('xl/'))
                                    return { ext: 'xlsx', mime: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' }
                                if (o.filename.startsWith('3D/') && o.filename.endsWith('.model'))
                                    return { ext: '3mf', mime: 'model/3mf' }
                                if ('mimetype' === o.filename && o.compressedSize === o.uncompressedSize)
                                    switch (await e.readToken(new Token.StringType(o.compressedSize, 'utf-8'))) {
                                        case 'application/epub+zip':
                                            return { ext: 'epub', mime: 'application/epub+zip' }
                                        case 'application/vnd.oasis.opendocument.text':
                                            return { ext: 'odt', mime: 'application/vnd.oasis.opendocument.text' }
                                        case 'application/vnd.oasis.opendocument.spreadsheet':
                                            return { ext: 'ods', mime: 'application/vnd.oasis.opendocument.spreadsheet' }
                                        case 'application/vnd.oasis.opendocument.presentation':
                                            return { ext: 'odp', mime: 'application/vnd.oasis.opendocument.presentation' }
                                    }
                                if (0 === o.compressedSize) {
                                    let s = -1
                                    for (; s < 0 && e.position < e.fileInfo.size;)
                                        await e.peekBuffer(t, { mayBeLess: !0 }),
                                            (s = t.indexOf('504B0304', 0, 'hex')),
                                            await e.ignore(s >= 0 ? s : t.length)
                                } else await e.ignore(o.compressedSize)
                            }
                        } catch (a) {
                            if (!(a instanceof strtok3.EndOfStreamError)) throw a
                        }
                        return { ext: 'zip', mime: 'application/zip' }
                    }
                    if (n('OggS')) {
                        await e.ignore(28)
                        const u = Buffer.alloc(8)
                        return (
                            await e.readBuffer(u),
                            _check(u, [79, 112, 117, 115, 72, 101, 97, 100])
                                ? { ext: 'opus', mime: 'audio/opus' }
                                : _check(u, [128, 116, 104, 101, 111, 114, 97])
                                    ? { ext: 'ogv', mime: 'video/ogg' }
                                    : _check(u, [1, 118, 105, 100, 101, 111, 0])
                                        ? { ext: 'ogm', mime: 'video/ogg' }
                                        : _check(u, [127, 70, 76, 65, 67])
                                            ? { ext: 'oga', mime: 'audio/ogg' }
                                            : _check(u, [83, 112, 101, 101, 120, 32, 32])
                                                ? { ext: 'spx', mime: 'audio/ogg' }
                                                : _check(u, [1, 118, 111, 114, 98, 105, 115])
                                                    ? { ext: 'ogg', mime: 'audio/ogg' }
                                                    : { ext: 'ogx', mime: 'application/ogg' }
                        )
                    }
                    if (r([80, 75]) && (3 === t[2] || 5 === t[2] || 7 === t[2]) && (4 === t[3] || 6 === t[3] || 8 === t[3]))
                        return { ext: 'zip', mime: 'application/zip' }
                    if (n('ftyp', { offset: 4 }) && 0 != (96 & t[8])) {
                        const c = t.toString('binary', 8, 12).replace('\0', ' ').trim()
                        switch (c) {
                            case 'avif':
                                return { ext: 'avif', mime: 'image/avif' }
                            case 'mif1':
                                return { ext: 'heic', mime: 'image/heif' }
                            case 'msf1':
                                return { ext: 'heic', mime: 'image/heif-sequence' }
                            case 'heic':
                            case 'heix':
                                return { ext: 'heic', mime: 'image/heic' }
                            case 'hevc':
                            case 'hevx':
                                return { ext: 'heic', mime: 'image/heic-sequence' }
                            case 'qt':
                                return { ext: 'mov', mime: 'video/quicktime' }
                            case 'M4V':
                            case 'M4VH':
                            case 'M4VP':
                                return { ext: 'm4v', mime: 'video/x-m4v' }
                            case 'M4P':
                                return { ext: 'm4p', mime: 'video/mp4' }
                            case 'M4B':
                                return { ext: 'm4b', mime: 'audio/mp4' }
                            case 'M4A':
                                return { ext: 'm4a', mime: 'audio/x-m4a' }
                            case 'F4V':
                                return { ext: 'f4v', mime: 'video/mp4' }
                            case 'F4P':
                                return { ext: 'f4p', mime: 'video/mp4' }
                            case 'F4A':
                                return { ext: 'f4a', mime: 'audio/mp4' }
                            case 'F4B':
                                return { ext: 'f4b', mime: 'audio/mp4' }
                            case 'crx':
                                return { ext: 'cr3', mime: 'image/x-canon-cr3' }
                            default:
                                return c.startsWith('3g')
                                    ? c.startsWith('3g2')
                                        ? { ext: '3g2', mime: 'video/3gpp2' }
                                        : { ext: '3gp', mime: 'video/3gpp' }
                                    : { ext: 'mp4', mime: 'video/mp4' }
                        }
                    }
                    if (n('MThd')) return { ext: 'mid', mime: 'audio/midi' }
                    if (n('wOFF') && (r([0, 1, 0, 0], { offset: 4 }) || n('OTTO', { offset: 4 })))
                        return { ext: 'woff', mime: 'font/woff' }
                    if (n('wOF2') && (r([0, 1, 0, 0], { offset: 4 }) || n('OTTO', { offset: 4 })))
                        return { ext: 'woff2', mime: 'font/woff2' }
                    if (r([212, 195, 178, 161]) || r([161, 178, 195, 212]))
                        return { ext: 'pcap', mime: 'application/vnd.tcpdump.pcap' }
                    if (n('DSD ')) return { ext: 'dsf', mime: 'audio/x-dsf' }
                    if (n('LZIP')) return { ext: 'lz', mime: 'application/x-lzip' }
                    if (n('fLaC')) return { ext: 'flac', mime: 'audio/x-flac' }
                    if (r([66, 80, 71, 251])) return { ext: 'bpg', mime: 'image/bpg' }
                    if (n('wvpk')) return { ext: 'wv', mime: 'audio/wavpack' }
                    if (n('%PDF')) {
                        await e.ignore(1350)
                        const l = 10485760,
                            d = Buffer.alloc(Math.min(l, e.fileInfo.size))
                        return (
                            await e.readBuffer(d, { mayBeLess: !0 }),
                            d.includes(Buffer.from('AIPrivateData'))
                                ? { ext: 'ai', mime: 'application/postscript' }
                                : { ext: 'pdf', mime: 'application/pdf' }
                        )
                    }
                    if (r([0, 97, 115, 109])) return { ext: 'wasm', mime: 'application/wasm' }
                    if (r([73, 73, 42, 0]))
                        return n('CR', { offset: 8 })
                            ? { ext: 'cr2', mime: 'image/x-canon-cr2' }
                            : r([28, 0, 254, 0], { offset: 8 }) || r([31, 0, 11, 0], { offset: 8 })
                                ? { ext: 'nef', mime: 'image/x-nikon-nef' }
                                : r([8, 0, 0, 0], { offset: 4 }) &&
                                    (r([45, 0, 254, 0], { offset: 8 }) || r([39, 0, 254, 0], { offset: 8 }))
                                    ? { ext: 'dng', mime: 'image/x-adobe-dng' }
                                    : ((t = Buffer.alloc(24)),
                                        await e.peekBuffer(t),
                                        (r([16, 251, 134, 1], { offset: 4 }) || r([8, 0, 0, 0], { offset: 4 })) &&
                                            r([0, 254, 0, 4, 0, 1, 0, 0, 0, 1, 0, 0, 0, 3, 1], { offset: 9 })
                                            ? { ext: 'arw', mime: 'image/x-sony-arw' }
                                            : { ext: 'tif', mime: 'image/tiff' })
                    if (r([77, 77, 0, 42])) return { ext: 'tif', mime: 'image/tiff' }
                    if (n('MAC ')) return { ext: 'ape', mime: 'audio/ape' }
                    if (r([26, 69, 223, 163])) {
                        async function f() {
                            const t = await e.peekNumber(Token.UINT8)
                            let r = 128,
                                n = 0
                            for (; 0 == (t & r) && 0 !== r;) ++n, (r >>= 1)
                            const i = Buffer.alloc(n + 1)
                            return await e.readBuffer(i), i
                        }
                        async function p() {
                            const e = await f(),
                                t = await f()
                            t[0] ^= 128 >> (t.length - 1)
                            const r = Math.min(6, t.length)
                            return { id: e.readUIntBE(0, e.length), len: t.readUIntBE(t.length - r, r) }
                        }
                        async function m(t, r) {
                            for (; r > 0;) {
                                const t = await p()
                                if (17026 === t.id) return e.readToken(new Token.StringType(t.len, 'utf-8'))
                                await e.ignore(t.len), --r
                            }
                        }
                        const g = await p()
                        switch (await m(0, g.len)) {
                            case 'webm':
                                return { ext: 'webm', mime: 'video/webm' }
                            case 'matroska':
                                return { ext: 'mkv', mime: 'video/x-matroska' }
                            default:
                                return
                        }
                    }
                    if (r([82, 73, 70, 70])) {
                        if (r([65, 86, 73], { offset: 8 })) return { ext: 'avi', mime: 'video/vnd.avi' }
                        if (r([87, 65, 86, 69], { offset: 8 })) return { ext: 'wav', mime: 'audio/vnd.wave' }
                        if (r([81, 76, 67, 77], { offset: 8 })) return { ext: 'qcp', mime: 'audio/qcelp' }
                    }
                    if (n('SQLi')) return { ext: 'sqlite', mime: 'application/x-sqlite3' }
                    if (r([78, 69, 83, 26])) return { ext: 'nes', mime: 'application/x-nintendo-nes-rom' }
                    if (n('Cr24')) return { ext: 'crx', mime: 'application/x-google-chrome-extension' }
                    if (n('MSCF') || n('ISc(')) return { ext: 'cab', mime: 'application/vnd.ms-cab-compressed' }
                    if (r([237, 171, 238, 219])) return { ext: 'rpm', mime: 'application/x-rpm' }
                    if (r([197, 208, 211, 198])) return { ext: 'eps', mime: 'application/eps' }
                    if (r([40, 181, 47, 253])) return { ext: 'zst', mime: 'application/zstd' }
                    if (r([79, 84, 84, 79, 0])) return { ext: 'otf', mime: 'font/otf' }
                    if (n('#!AMR')) return { ext: 'amr', mime: 'audio/amr' }
                    if (n('{\\rtf')) return { ext: 'rtf', mime: 'application/rtf' }
                    if (r([70, 76, 86, 1])) return { ext: 'flv', mime: 'video/x-flv' }
                    if (n('IMPM')) return { ext: 'it', mime: 'audio/x-it' }
                    if (
                        n('-lh0-', { offset: 2 }) ||
                        n('-lh1-', { offset: 2 }) ||
                        n('-lh2-', { offset: 2 }) ||
                        n('-lh3-', { offset: 2 }) ||
                        n('-lh4-', { offset: 2 }) ||
                        n('-lh5-', { offset: 2 }) ||
                        n('-lh6-', { offset: 2 }) ||
                        n('-lh7-', { offset: 2 }) ||
                        n('-lzs-', { offset: 2 }) ||
                        n('-lz4-', { offset: 2 }) ||
                        n('-lz5-', { offset: 2 }) ||
                        n('-lhd-', { offset: 2 })
                    )
                        return { ext: 'lzh', mime: 'application/x-lzh-compressed' }
                    if (r([0, 0, 1, 186])) {
                        if (r([33], { offset: 4, mask: [241] })) return { ext: 'mpg', mime: 'video/MP1S' }
                        if (r([68], { offset: 4, mask: [196] })) return { ext: 'mpg', mime: 'video/MP2P' }
                    }
                    if (n('ITSF')) return { ext: 'chm', mime: 'application/vnd.ms-htmlhelp' }
                    if (r([253, 55, 122, 88, 90, 0])) return { ext: 'xz', mime: 'application/x-xz' }
                    if (n('<?xml ')) return { ext: 'xml', mime: 'application/xml' }
                    if (r([55, 122, 188, 175, 39, 28])) return { ext: '7z', mime: 'application/x-7z-compressed' }
                    if (r([82, 97, 114, 33, 26, 7]) && (0 === t[6] || 1 === t[6]))
                        return { ext: 'rar', mime: 'application/x-rar-compressed' }
                    if (n('solid ')) return { ext: 'stl', mime: 'model/stl' }
                    if (n('BLENDER')) return { ext: 'blend', mime: 'application/x-blender' }
                    if (n('!<arch>'))
                        return (
                            await e.ignore(8),
                            'debian-binary' === (await e.readToken(new Token.StringType(13, 'ascii')))
                                ? { ext: 'deb', mime: 'application/x-deb' }
                                : { ext: 'ar', mime: 'application/x-unix-archive' }
                        )
                    if (r([137, 80, 78, 71, 13, 10, 26, 10])) {
                        async function h() {
                            return {
                                length: await e.readToken(Token.INT32_BE),
                                type: await e.readToken(new Token.StringType(4, 'binary'))
                            }
                        }
                        await e.ignore(8)
                        do {
                            const y = await h()
                            if (y.length < 0) return
                            switch (y.type) {
                                case 'IDAT':
                                    return { ext: 'png', mime: 'image/png' }
                                case 'acTL':
                                    return { ext: 'apng', mime: 'image/apng' }
                                default:
                                    await e.ignore(y.length + 4)
                            }
                        } while (e.position + 8 < e.fileInfo.size)
                        return { ext: 'png', mime: 'image/png' }
                    }
                    if (r([65, 82, 82, 79, 87, 49, 0, 0])) return { ext: 'arrow', mime: 'application/x-apache-arrow' }
                    if (r([103, 108, 84, 70, 2, 0, 0, 0])) return { ext: 'glb', mime: 'model/gltf-binary' }
                    if (
                        r([102, 114, 101, 101], { offset: 4 }) ||
                        r([109, 100, 97, 116], { offset: 4 }) ||
                        r([109, 111, 111, 118], { offset: 4 }) ||
                        r([119, 105, 100, 101], { offset: 4 })
                    )
                        return { ext: 'mov', mime: 'video/quicktime' }
                    if (r([73, 73, 82, 79, 8, 0, 0, 0, 24])) return { ext: 'orf', mime: 'image/x-olympus-orf' }
                    if (n('gimp xcf ')) return { ext: 'xcf', mime: 'image/x-xcf' }
                    if (r([73, 73, 85, 0, 24, 0, 0, 0, 136, 231, 116, 216]))
                        return { ext: 'rw2', mime: 'image/x-panasonic-rw2' }
                    if (r([48, 38, 178, 117, 142, 102, 207, 17, 166, 217])) {
                        async function b() {
                            const t = Buffer.alloc(16)
                            return await e.readBuffer(t), { id: t, size: Number(await e.readToken(Token.UINT64_LE)) }
                        }
                        for (await e.ignore(30); e.position + 24 < e.fileInfo.size;) {
                            const v = await b()
                            let _ = v.size - 24
                            if (_check(v.id, [145, 7, 220, 183, 183, 169, 207, 17, 142, 230, 0, 192, 12, 32, 83, 101])) {
                                const M = Buffer.alloc(16)
                                if (
                                    ((_ -= await e.readBuffer(M)),
                                        _check(M, [64, 158, 105, 248, 77, 91, 207, 17, 168, 253, 0, 128, 95, 92, 68, 43]))
                                )
                                    return { ext: 'asf', mime: 'audio/x-ms-asf' }
                                if (_check(M, [192, 239, 25, 188, 77, 91, 207, 17, 168, 253, 0, 128, 95, 92, 68, 43]))
                                    return { ext: 'asf', mime: 'video/x-ms-asf' }
                                break
                            }
                            await e.ignore(_)
                        }
                        return { ext: 'asf', mime: 'application/vnd.ms-asf' }
                    }
                    if (r([171, 75, 84, 88, 32, 49, 49, 187, 13, 10, 26, 10])) return { ext: 'ktx', mime: 'image/ktx' }
                    if ((r([126, 16, 4]) || r([126, 24, 4])) && r([48, 77, 73, 69], { offset: 4 }))
                        return { ext: 'mie', mime: 'application/x-mie' }
                    if (r([39, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], { offset: 2 }))
                        return { ext: 'shp', mime: 'application/x-esri-shape' }
                    if (r([0, 0, 0, 12, 106, 80, 32, 32, 13, 10, 135, 10]))
                        switch ((await e.ignore(20), await e.readToken(new Token.StringType(4, 'ascii')))) {
                            case 'jp2 ':
                                return { ext: 'jp2', mime: 'image/jp2' }
                            case 'jpx ':
                                return { ext: 'jpx', mime: 'image/jpx' }
                            case 'jpm ':
                                return { ext: 'jpm', mime: 'image/jpm' }
                            case 'mjp2':
                                return { ext: 'mj2', mime: 'image/mj2' }
                            default:
                                return
                        }
                    if (r([255, 10]) || r([0, 0, 0, 12, 74, 88, 76, 32, 13, 10, 135, 10]))
                        return { ext: 'jxl', mime: 'image/jxl' }
                    if (r([0, 0, 1, 186]) || r([0, 0, 1, 179])) return { ext: 'mpg', mime: 'video/mpeg' }
                    if (r([0, 1, 0, 0, 0])) return { ext: 'ttf', mime: 'font/ttf' }
                    if (r([0, 0, 1, 0])) return { ext: 'ico', mime: 'image/x-icon' }
                    if (r([0, 0, 2, 0])) return { ext: 'cur', mime: 'image/x-icon' }
                    if (r([208, 207, 17, 224, 161, 177, 26, 225])) return { ext: 'cfb', mime: 'application/x-cfb' }
                    if ((await e.peekBuffer(t, { length: Math.min(256, e.fileInfo.size), mayBeLess: !0 }), n('BEGIN:'))) {
                        if (n('VCARD', { offset: 6 })) return { ext: 'vcf', mime: 'text/vcard' }
                        if (n('VCALENDAR', { offset: 6 })) return { ext: 'ics', mime: 'text/calendar' }
                    }
                    if (n('FUJIFILMCCD-RAW')) return { ext: 'raf', mime: 'image/x-fujifilm-raf' }
                    if (n('Extended Module:')) return { ext: 'xm', mime: 'audio/x-xm' }
                    if (n('Creative Voice File')) return { ext: 'voc', mime: 'audio/x-voc' }
                    if (r([4, 0, 0, 0]) && t.length >= 16) {
                        const P = t.readUInt32LE(12)
                        if (P > 12 && t.length >= P + 16)
                            try {
                                const w = t.slice(16, P + 16).toString()
                                if (JSON.parse(w).files) return { ext: 'asar', mime: 'application/x-asar' }
                            } catch (O) { }
                    }
                    if (r([6, 14, 43, 52, 2, 5, 1, 1, 13, 1, 2, 1, 1, 2])) return { ext: 'mxf', mime: 'application/mxf' }
                    if (n('SCRM', { offset: 44 })) return { ext: 's3m', mime: 'audio/x-s3m' }
                    if (r([71], { offset: 4 }) && (r([71], { offset: 192 }) || r([71], { offset: 196 })))
                        return { ext: 'mts', mime: 'video/mp2t' }
                    if (r([66, 79, 79, 75, 77, 79, 66, 73], { offset: 60 }))
                        return { ext: 'mobi', mime: 'application/x-mobipocket-ebook' }
                    if (r([68, 73, 67, 77], { offset: 128 })) return { ext: 'dcm', mime: 'application/dicom' }
                    if (r([76, 0, 0, 0, 1, 20, 2, 0, 0, 0, 0, 0, 192, 0, 0, 0, 0, 0, 0, 70]))
                        return { ext: 'lnk', mime: 'application/x.ms.shortcut' }
                    if (r([98, 111, 111, 107, 0, 0, 0, 0, 109, 97, 114, 107, 0, 0, 0, 0]))
                        return { ext: 'alias', mime: 'application/x.apple.alias' }
                    if (
                        r([76, 80], { offset: 34 }) &&
                        (r([0, 0, 1], { offset: 8 }) || r([1, 0, 2], { offset: 8 }) || r([2, 0, 2], { offset: 8 }))
                    )
                        return { ext: 'eot', mime: 'application/vnd.ms-fontobject' }
                    if (r([6, 6, 237, 245, 216, 29, 70, 229, 189, 49, 239, 231, 254, 116, 183, 29]))
                        return { ext: 'indd', mime: 'application/x-indesign' }
                    if (
                        (await e.peekBuffer(t, { length: Math.min(512, e.fileInfo.size), mayBeLess: !0 }),
                            tarHeaderChecksumMatches(t))
                    )
                        return { ext: 'tar', mime: 'application/x-tar' }
                    if (
                        r([
                            255, 254, 255, 14, 83, 0, 107, 0, 101, 0, 116, 0, 99, 0, 104, 0, 85, 0, 112, 0, 32, 0, 77, 0, 111, 0,
                            100, 0, 101, 0, 108, 0
                        ])
                    )
                        return { ext: 'skp', mime: 'application/vnd.sketchup.skp' }
                    if (n('-----BEGIN PGP MESSAGE-----')) return { ext: 'pgp', mime: 'application/pgp-encrypted' }
                    if (t.length >= 2 && r([255, 224], { offset: 0, mask: [255, 224] })) {
                        if (r([16], { offset: 1, mask: [22] }))
                            return r([8], { offset: 1, mask: [8] }), { ext: 'aac', mime: 'audio/aac' }
                        if (r([2], { offset: 1, mask: [6] })) return { ext: 'mp3', mime: 'audio/mpeg' }
                        if (r([4], { offset: 1, mask: [6] })) return { ext: 'mp2', mime: 'audio/mpeg' }
                        if (r([6], { offset: 1, mask: [6] })) return { ext: 'mp1', mime: 'audio/mpeg' }
                    }
                }
                const stream = (readableStream) =>
                    new Promise((resolve, reject) => {
                        const stream = eval('require')('stream')
                        readableStream.on('error', reject),
                            readableStream.once('readable', async () => {
                                const e = new stream.PassThrough()
                                let t
                                t = stream.pipeline ? stream.pipeline(readableStream, e, () => { }) : readableStream.pipe(e)
                                const r = readableStream.read(minimumBytes) || readableStream.read() || Buffer.alloc(0)
                                try {
                                    const t = await fromBuffer(r)
                                    e.fileType = t
                                } catch (e) {
                                    reject(e)
                                }
                                resolve(t)
                            })
                    }),
                    fileType = { fromStream, fromTokenizer, fromBuffer, stream }
                Object.defineProperty(fileType, 'extensions', { get: () => new Set(supported.extensions) }),
                    Object.defineProperty(fileType, 'mimeTypes', { get: () => new Set(supported.mimeTypes) }),
                    (module.exports = fileType)
            },
            5834: (e, t, r) => {
                'use strict'
                const n = r(3358),
                    i = r(9172),
                    o = {
                        fromFile: async function (e) {
                            const t = await n.fromFile(e)
                            try {
                                return await i.fromTokenizer(t)
                            } finally {
                                await t.close()
                            }
                        }
                    }
                Object.assign(o, i),
                    Object.defineProperty(o, 'extensions', { get: () => i.extensions }),
                    Object.defineProperty(o, 'mimeTypes', { get: () => i.mimeTypes }),
                    (e.exports = o)
            },
            2453: (e) => {
                'use strict'
                e.exports = {
                    extensions: [
                        'jpg',
                        'png',
                        'apng',
                        'gif',
                        'webp',
                        'flif',
                        'xcf',
                        'cr2',
                        'cr3',
                        'orf',
                        'arw',
                        'dng',
                        'nef',
                        'rw2',
                        'raf',
                        'tif',
                        'bmp',
                        'icns',
                        'jxr',
                        'psd',
                        'indd',
                        'zip',
                        'tar',
                        'rar',
                        'gz',
                        'bz2',
                        '7z',
                        'dmg',
                        'mp4',
                        'mid',
                        'mkv',
                        'webm',
                        'mov',
                        'avi',
                        'mpg',
                        'mp2',
                        'mp3',
                        'm4a',
                        'oga',
                        'ogg',
                        'ogv',
                        'opus',
                        'flac',
                        'wav',
                        'spx',
                        'amr',
                        'pdf',
                        'epub',
                        'exe',
                        'swf',
                        'rtf',
                        'wasm',
                        'woff',
                        'woff2',
                        'eot',
                        'ttf',
                        'otf',
                        'ico',
                        'flv',
                        'ps',
                        'xz',
                        'sqlite',
                        'nes',
                        'crx',
                        'xpi',
                        'cab',
                        'deb',
                        'ar',
                        'rpm',
                        'Z',
                        'lz',
                        'cfb',
                        'mxf',
                        'mts',
                        'blend',
                        'bpg',
                        'docx',
                        'pptx',
                        'xlsx',
                        '3gp',
                        '3g2',
                        'jp2',
                        'jpm',
                        'jpx',
                        'mj2',
                        'aif',
                        'qcp',
                        'odt',
                        'ods',
                        'odp',
                        'xml',
                        'mobi',
                        'heic',
                        'cur',
                        'ktx',
                        'ape',
                        'wv',
                        'dcm',
                        'ics',
                        'glb',
                        'pcap',
                        'dsf',
                        'lnk',
                        'alias',
                        'voc',
                        'ac3',
                        'm4v',
                        'm4p',
                        'm4b',
                        'f4v',
                        'f4p',
                        'f4b',
                        'f4a',
                        'mie',
                        'asf',
                        'ogm',
                        'ogx',
                        'mpc',
                        'arrow',
                        'shp',
                        'aac',
                        'mp1',
                        'it',
                        's3m',
                        'xm',
                        'ai',
                        'skp',
                        'avif',
                        'eps',
                        'lzh',
                        'pgp',
                        'asar',
                        'stl',
                        'chm',
                        '3mf',
                        'zst',
                        'jxl',
                        'vcf'
                    ],
                    mimeTypes: [
                        'image/jpeg',
                        'image/png',
                        'image/gif',
                        'image/webp',
                        'image/flif',
                        'image/x-xcf',
                        'image/x-canon-cr2',
                        'image/x-canon-cr3',
                        'image/tiff',
                        'image/bmp',
                        'image/vnd.ms-photo',
                        'image/vnd.adobe.photoshop',
                        'application/x-indesign',
                        'application/epub+zip',
                        'application/x-xpinstall',
                        'application/vnd.oasis.opendocument.text',
                        'application/vnd.oasis.opendocument.spreadsheet',
                        'application/vnd.oasis.opendocument.presentation',
                        'application/vnd.openxmlformats-officedocument.wordprocessingml.document',
                        'application/vnd.openxmlformats-officedocument.presentationml.presentation',
                        'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
                        'application/zip',
                        'application/x-tar',
                        'application/x-rar-compressed',
                        'application/gzip',
                        'application/x-bzip2',
                        'application/x-7z-compressed',
                        'application/x-apple-diskimage',
                        'application/x-apache-arrow',
                        'video/mp4',
                        'audio/midi',
                        'video/x-matroska',
                        'video/webm',
                        'video/quicktime',
                        'video/vnd.avi',
                        'audio/vnd.wave',
                        'audio/qcelp',
                        'audio/x-ms-asf',
                        'video/x-ms-asf',
                        'application/vnd.ms-asf',
                        'video/mpeg',
                        'video/3gpp',
                        'audio/mpeg',
                        'audio/mp4',
                        'audio/opus',
                        'video/ogg',
                        'audio/ogg',
                        'application/ogg',
                        'audio/x-flac',
                        'audio/ape',
                        'audio/wavpack',
                        'audio/amr',
                        'application/pdf',
                        'application/x-msdownload',
                        'application/x-shockwave-flash',
                        'application/rtf',
                        'application/wasm',
                        'font/woff',
                        'font/woff2',
                        'application/vnd.ms-fontobject',
                        'font/ttf',
                        'font/otf',
                        'image/x-icon',
                        'video/x-flv',
                        'application/postscript',
                        'application/eps',
                        'application/x-xz',
                        'application/x-sqlite3',
                        'application/x-nintendo-nes-rom',
                        'application/x-google-chrome-extension',
                        'application/vnd.ms-cab-compressed',
                        'application/x-deb',
                        'application/x-unix-archive',
                        'application/x-rpm',
                        'application/x-compress',
                        'application/x-lzip',
                        'application/x-cfb',
                        'application/x-mie',
                        'application/mxf',
                        'video/mp2t',
                        'application/x-blender',
                        'image/bpg',
                        'image/jp2',
                        'image/jpx',
                        'image/jpm',
                        'image/mj2',
                        'audio/aiff',
                        'application/xml',
                        'application/x-mobipocket-ebook',
                        'image/heif',
                        'image/heif-sequence',
                        'image/heic',
                        'image/heic-sequence',
                        'image/icns',
                        'image/ktx',
                        'application/dicom',
                        'audio/x-musepack',
                        'text/calendar',
                        'text/vcard',
                        'model/gltf-binary',
                        'application/vnd.tcpdump.pcap',
                        'audio/x-dsf',
                        'application/x.ms.shortcut',
                        'application/x.apple.alias',
                        'audio/x-voc',
                        'audio/vnd.dolby.dd-raw',
                        'audio/x-m4a',
                        'image/apng',
                        'image/x-olympus-orf',
                        'image/x-sony-arw',
                        'image/x-adobe-dng',
                        'image/x-nikon-nef',
                        'image/x-panasonic-rw2',
                        'image/x-fujifilm-raf',
                        'video/x-m4v',
                        'video/3gpp2',
                        'application/x-esri-shape',
                        'audio/aac',
                        'audio/x-it',
                        'audio/x-s3m',
                        'audio/x-xm',
                        'video/MP1S',
                        'video/MP2P',
                        'application/vnd.sketchup.skp',
                        'image/avif',
                        'application/x-lzh-compressed',
                        'application/pgp-encrypted',
                        'application/x-asar',
                        'model/stl',
                        'application/vnd.ms-htmlhelp',
                        'model/3mf',
                        'image/jxl',
                        'application/zstd'
                    ]
                }
            },
            6622: (e, t) => {
                'use strict'
                    ; (t.stringToBytes = (e) => [...e].map((e) => e.charCodeAt(0))),
                        (t.tarHeaderChecksumMatches = (e, t = 0) => {
                            const r = parseInt(e.toString('utf8', 148, 154).replace(/\0.*$/, '').trim(), 8)
                            if (isNaN(r)) return !1
                            let n = 256
                            for (let r = t; r < t + 148; r++) n += e[r]
                            for (let r = t + 156; r < t + 512; r++) n += e[r]
                            return r === n
                        }),
                        (t.uint32SyncSafeToken = {
                            get: (e, t) => (127 & e[t + 3]) | (e[t + 2] << 7) | (e[t + 1] << 14) | (e[t] << 21),
                            len: 4
                        })
            },
            7467: (e, t) => {
                ; (t.read = function (e, t, r, n, i) {
                    var o,
                        s,
                        a = 8 * i - n - 1,
                        u = (1 << a) - 1,
                        c = u >> 1,
                        l = -7,
                        d = r ? i - 1 : 0,
                        f = r ? -1 : 1,
                        p = e[t + d]
                    for (d += f, o = p & ((1 << -l) - 1), p >>= -l, l += a; l > 0; o = 256 * o + e[t + d], d += f, l -= 8);
                    for (s = o & ((1 << -l) - 1), o >>= -l, l += n; l > 0; s = 256 * s + e[t + d], d += f, l -= 8);
                    if (0 === o) o = 1 - c
                    else {
                        if (o === u) return s ? NaN : (1 / 0) * (p ? -1 : 1)
                            ; (s += Math.pow(2, n)), (o -= c)
                    }
                    return (p ? -1 : 1) * s * Math.pow(2, o - n)
                }),
                    (t.write = function (e, t, r, n, i, o) {
                        var s,
                            a,
                            u,
                            c = 8 * o - i - 1,
                            l = (1 << c) - 1,
                            d = l >> 1,
                            f = 23 === i ? Math.pow(2, -24) - Math.pow(2, -77) : 0,
                            p = n ? 0 : o - 1,
                            m = n ? 1 : -1,
                            g = t < 0 || (0 === t && 1 / t < 0) ? 1 : 0
                        for (
                            t = Math.abs(t),
                            isNaN(t) || t === 1 / 0
                                ? ((a = isNaN(t) ? 1 : 0), (s = l))
                                : ((s = Math.floor(Math.log(t) / Math.LN2)),
                                    t * (u = Math.pow(2, -s)) < 1 && (s--, (u *= 2)),
                                    (t += s + d >= 1 ? f / u : f * Math.pow(2, 1 - d)) * u >= 2 && (s++, (u /= 2)),
                                    s + d >= l
                                        ? ((a = 0), (s = l))
                                        : s + d >= 1
                                            ? ((a = (t * u - 1) * Math.pow(2, i)), (s += d))
                                            : ((a = t * Math.pow(2, d - 1) * Math.pow(2, i)), (s = 0)));
                            i >= 8;
                            e[r + p] = 255 & a, p += m, a /= 256, i -= 8
                        );
                        for (s = (s << i) | a, c += i; c > 0; e[r + p] = 255 & s, p += m, s /= 256, c -= 8);
                        e[r + p - m] |= 128 * g
                    })
            },
            6847: (e) => {
                var t = 1e3,
                    r = 60 * t,
                    n = 60 * r,
                    i = 24 * n
                function o(e, t, r, n) {
                    var i = t >= 1.5 * r
                    return Math.round(e / r) + ' ' + n + (i ? 's' : '')
                }
                e.exports = function (e, s) {
                    s = s || {}
                    var a,
                        u,
                        c = typeof e
                    if ('string' === c && e.length > 0)
                        return (function (e) {
                            if (!((e = String(e)).length > 100)) {
                                var o =
                                    /^(-?(?:\d+)?\.?\d+) *(milliseconds?|msecs?|ms|seconds?|secs?|s|minutes?|mins?|m|hours?|hrs?|h|days?|d|weeks?|w|years?|yrs?|y)?$/i.exec(
                                        e
                                    )
                                if (o) {
                                    var s = parseFloat(o[1])
                                    switch ((o[2] || 'ms').toLowerCase()) {
                                        case 'years':
                                        case 'year':
                                        case 'yrs':
                                        case 'yr':
                                        case 'y':
                                            return 315576e5 * s
                                        case 'weeks':
                                        case 'week':
                                        case 'w':
                                            return 6048e5 * s
                                        case 'days':
                                        case 'day':
                                        case 'd':
                                            return s * i
                                        case 'hours':
                                        case 'hour':
                                        case 'hrs':
                                        case 'hr':
                                        case 'h':
                                            return s * n
                                        case 'minutes':
                                        case 'minute':
                                        case 'mins':
                                        case 'min':
                                        case 'm':
                                            return s * r
                                        case 'seconds':
                                        case 'second':
                                        case 'secs':
                                        case 'sec':
                                        case 's':
                                            return s * t
                                        case 'milliseconds':
                                        case 'millisecond':
                                        case 'msecs':
                                        case 'msec':
                                        case 'ms':
                                            return s
                                        default:
                                            return
                                    }
                                }
                            }
                        })(e)
                    if ('number' === c && isFinite(e))
                        return s.long
                            ? ((a = e),
                                (u = Math.abs(a)) >= i
                                    ? o(a, u, i, 'day')
                                    : u >= n
                                        ? o(a, u, n, 'hour')
                                        : u >= r
                                            ? o(a, u, r, 'minute')
                                            : u >= t
                                                ? o(a, u, t, 'second')
                                                : a + ' ms')
                            : (function (e) {
                                var o = Math.abs(e)
                                return o >= i
                                    ? Math.round(e / i) + 'd'
                                    : o >= n
                                        ? Math.round(e / n) + 'h'
                                        : o >= r
                                            ? Math.round(e / r) + 'm'
                                            : o >= t
                                                ? Math.round(e / t) + 's'
                                                : e + 'ms'
                            })(e)
                    throw new Error('val is not a non-empty string or a valid number. val=' + JSON.stringify(e))
                }
            },
            5705: (e, t, r) => {
                'use strict'
                var n = r(692).lW
                const i = r(7425)
                e.exports = (e) => {
                    if (!i(e)) return !1
                    const t = e.trim().match(i.regex),
                        r = {}
                    if (t[1]) {
                        r.mediaType = t[1].toLowerCase()
                        const e = t[1].split(';').map((e) => e.toLowerCase())
                            ; (r.contentType = e[0]),
                                e.slice(1).forEach((e) => {
                                    const t = e.split('=')
                                    r[t[0]] = t[1]
                                })
                    }
                    return (
                        (r.base64 = !!t[t.length - 2]),
                        (r.data = t[t.length - 1] || ''),
                        (r.toBuffer = () => {
                            const e = r.base64 ? 'base64' : 'utf8'
                            return n.from(r.data, e)
                        }),
                        r
                    )
                }
            },
            5911: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.Deferred = void 0),
                    (t.Deferred = class {
                        constructor() {
                            ; (this.resolve = () => null),
                                (this.reject = () => null),
                                (this.promise = new Promise((e, t) => {
                                    ; (this.reject = t), (this.resolve = e)
                                }))
                        }
                    })
            },
            9839: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.EndOfStreamError = t.defaultMessages = void 0),
                    (t.defaultMessages = 'End-Of-Stream')
                class r extends Error {
                    constructor() {
                        super(t.defaultMessages)
                    }
                }
                t.EndOfStreamError = r
            },
            4223: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.StreamReader = t.EndOfStreamError = void 0)
                const n = r(9839),
                    i = r(5911)
                var o = r(9839)
                Object.defineProperty(t, 'EndOfStreamError', {
                    enumerable: !0,
                    get: function () {
                        return o.EndOfStreamError
                    }
                }),
                    (t.StreamReader = class {
                        constructor(e) {
                            if (
                                ((this.s = e),
                                    (this.deferred = null),
                                    (this.endOfStream = !1),
                                    (this.peekQueue = []),
                                    !e.read || !e.once)
                            )
                                throw new Error('Expected an instance of stream.Readable')
                            this.s.once('end', () => this.reject(new n.EndOfStreamError())),
                                this.s.once('error', (e) => this.reject(e)),
                                this.s.once('close', () => this.reject(new Error('Stream closed')))
                        }
                        async peek(e, t, r) {
                            const n = await this.read(e, t, r)
                            return this.peekQueue.push(e.subarray(t, t + n)), n
                        }
                        async read(e, t, r) {
                            if (0 === r) return 0
                            if (0 === this.peekQueue.length && this.endOfStream) throw new n.EndOfStreamError()
                            let i = r,
                                o = 0
                            for (; this.peekQueue.length > 0 && i > 0;) {
                                const r = this.peekQueue.pop()
                                if (!r) throw new Error('peekData should be defined')
                                const n = Math.min(r.length, i)
                                e.set(r.subarray(0, n), t + o), (o += n), (i -= n), n < r.length && this.peekQueue.push(r.subarray(n))
                            }
                            for (; i > 0 && !this.endOfStream;) {
                                const r = Math.min(i, 1048576),
                                    n = await this.readFromStream(e, t + o, r)
                                if (((o += n), n < r)) break
                                i -= n
                            }
                            return o
                        }
                        async readFromStream(e, t, r) {
                            const n = this.s.read(r)
                            if (n) return e.set(n, t), n.length
                            {
                                const n = { buffer: e, offset: t, length: r, deferred: new i.Deferred() }
                                return (
                                    (this.deferred = n.deferred),
                                    this.s.once('readable', () => {
                                        this.readDeferred(n)
                                    }),
                                    n.deferred.promise
                                )
                            }
                        }
                        readDeferred(e) {
                            const t = this.s.read(e.length)
                            t
                                ? (e.buffer.set(t, e.offset), e.deferred.resolve(t.length), (this.deferred = null))
                                : this.s.once('readable', () => {
                                    this.readDeferred(e)
                                })
                        }
                        reject(e) {
                            ; (this.endOfStream = !0), this.deferred && (this.deferred.reject(e), (this.deferred = null))
                        }
                    })
            },
            4682: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.StreamReader = t.EndOfStreamError = void 0)
                var n = r(9839)
                Object.defineProperty(t, 'EndOfStreamError', {
                    enumerable: !0,
                    get: function () {
                        return n.EndOfStreamError
                    }
                })
                var i = r(4223)
                Object.defineProperty(t, 'StreamReader', {
                    enumerable: !0,
                    get: function () {
                        return i.StreamReader
                    }
                })
            },
            2851: (e, t, r) => {
                'use strict'
                var n = r(692).lW
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.AbstractTokenizer = void 0)
                const i = r(4682)
                t.AbstractTokenizer = class {
                    constructor(e) {
                        ; (this.position = 0), (this.numBuffer = new Uint8Array(8)), (this.fileInfo = e || {})
                    }
                    async readToken(e, t = this.position) {
                        const r = n.alloc(e.len)
                        if ((await this.readBuffer(r, { position: t })) < e.len) throw new i.EndOfStreamError()
                        return e.get(r, 0)
                    }
                    async peekToken(e, t = this.position) {
                        const r = n.alloc(e.len)
                        if ((await this.peekBuffer(r, { position: t })) < e.len) throw new i.EndOfStreamError()
                        return e.get(r, 0)
                    }
                    async readNumber(e) {
                        if ((await this.readBuffer(this.numBuffer, { length: e.len })) < e.len) throw new i.EndOfStreamError()
                        return e.get(this.numBuffer, 0)
                    }
                    async peekNumber(e) {
                        if ((await this.peekBuffer(this.numBuffer, { length: e.len })) < e.len) throw new i.EndOfStreamError()
                        return e.get(this.numBuffer, 0)
                    }
                    async ignore(e) {
                        if (void 0 !== this.fileInfo.size) {
                            const t = this.fileInfo.size - this.position
                            if (e > t) return (this.position += t), t
                        }
                        return (this.position += e), e
                    }
                    async close() { }
                    normalizeOptions(e, t) {
                        if (t && void 0 !== t.position && t.position < this.position)
                            throw new Error('`options.position` must be equal or greater than `tokenizer.position`')
                        return t
                            ? {
                                mayBeLess: !0 === t.mayBeLess,
                                offset: t.offset ? t.offset : 0,
                                length: t.length ? t.length : e.length - (t.offset ? t.offset : 0),
                                position: t.position ? t.position : this.position
                            }
                            : { mayBeLess: !1, offset: 0, length: e.length, position: this.position }
                    }
                }
            },
            421: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.BufferTokenizer = void 0)
                const n = r(4682),
                    i = r(2851)
                class o extends i.AbstractTokenizer {
                    constructor(e, t) {
                        super(t), (this.uint8Array = e), (this.fileInfo.size = this.fileInfo.size ? this.fileInfo.size : e.length)
                    }
                    async readBuffer(e, t) {
                        if (t && t.position) {
                            if (t.position < this.position)
                                throw new Error('`options.position` must be equal or greater than `tokenizer.position`')
                            this.position = t.position
                        }
                        const r = await this.peekBuffer(e, t)
                        return (this.position += r), r
                    }
                    async peekBuffer(e, t) {
                        const r = this.normalizeOptions(e, t),
                            i = Math.min(this.uint8Array.length - r.position, r.length)
                        if (!r.mayBeLess && i < r.length) throw new n.EndOfStreamError()
                        return e.set(this.uint8Array.subarray(r.position, r.position + i), r.offset), i
                    }
                    async close() { }
                }
                t.BufferTokenizer = o
            },
            1916: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.fromFile = t.FileTokenizer = void 0)
                const n = r(2851),
                    i = r(4682),
                    o = r(6283)
                class s extends n.AbstractTokenizer {
                    constructor(e, t) {
                        super(t), (this.fd = e)
                    }
                    async readBuffer(e, t) {
                        const r = this.normalizeOptions(e, t)
                        this.position = r.position
                        const n = await o.read(this.fd, e, r.offset, r.length, r.position)
                        if (((this.position += n.bytesRead), n.bytesRead < r.length && (!t || !t.mayBeLess)))
                            throw new i.EndOfStreamError()
                        return n.bytesRead
                    }
                    async peekBuffer(e, t) {
                        const r = this.normalizeOptions(e, t),
                            n = await o.read(this.fd, e, r.offset, r.length, r.position)
                        if (!r.mayBeLess && n.bytesRead < r.length) throw new i.EndOfStreamError()
                        return n.bytesRead
                    }
                    async close() {
                        return o.close(this.fd)
                    }
                }
                ; (t.FileTokenizer = s),
                    (t.fromFile = async function (e) {
                        const t = await o.stat(e)
                        if (!t.isFile) throw new Error(`File not a file: ${e}`)
                        const r = await o.open(e, 'r')
                        return new s(r, { path: e, size: t.size })
                    })
            },
            6283: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.readFile =
                        t.writeFileSync =
                        t.writeFile =
                        t.read =
                        t.open =
                        t.close =
                        t.stat =
                        t.createReadStream =
                        t.pathExists =
                        void 0)
                const n = r(6897)
                    ; (t.pathExists = n.existsSync),
                        (t.createReadStream = n.createReadStream),
                        (t.stat = async function (e) {
                            return new Promise((t, r) => {
                                n.stat(e, (e, n) => {
                                    e ? r(e) : t(n)
                                })
                            })
                        }),
                        (t.close = async function (e) {
                            return new Promise((t, r) => {
                                n.close(e, (e) => {
                                    e ? r(e) : t()
                                })
                            })
                        }),
                        (t.open = async function (e, t) {
                            return new Promise((r, i) => {
                                n.open(e, t, (e, t) => {
                                    e ? i(e) : r(t)
                                })
                            })
                        }),
                        (t.read = async function (e, t, r, i, o) {
                            return new Promise((s, a) => {
                                n.read(e, t, r, i, o, (e, t, r) => {
                                    e ? a(e) : s({ bytesRead: t, buffer: r })
                                })
                            })
                        }),
                        (t.writeFile = async function (e, t) {
                            return new Promise((r, i) => {
                                n.writeFile(e, t, (e) => {
                                    e ? i(e) : r()
                                })
                            })
                        }),
                        (t.writeFileSync = function (e, t) {
                            n.writeFileSync(e, t)
                        }),
                        (t.readFile = async function (e) {
                            return new Promise((t, r) => {
                                n.readFile(e, (e, n) => {
                                    e ? r(e) : t(n)
                                })
                            })
                        })
            },
            6391: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.ReadStreamTokenizer = void 0)
                const n = r(2851),
                    i = r(4682)
                class o extends n.AbstractTokenizer {
                    constructor(e, t) {
                        super(t), (this.streamReader = new i.StreamReader(e))
                    }
                    async getFileInfo() {
                        return this.fileInfo
                    }
                    async readBuffer(e, t) {
                        const r = this.normalizeOptions(e, t),
                            n = r.position - this.position
                        if (n > 0) return await this.ignore(n), this.readBuffer(e, t)
                        if (n < 0) throw new Error('`options.position` must be equal or greater than `tokenizer.position`')
                        if (0 === r.length) return 0
                        const o = await this.streamReader.read(e, r.offset, r.length)
                        if (((this.position += o), (!t || !t.mayBeLess) && o < r.length)) throw new i.EndOfStreamError()
                        return o
                    }
                    async peekBuffer(e, t) {
                        const r = this.normalizeOptions(e, t)
                        let n = 0
                        if (r.position) {
                            const t = r.position - this.position
                            if (t > 0) {
                                const i = new Uint8Array(r.length + t)
                                return (
                                    (n = await this.peekBuffer(i, { mayBeLess: r.mayBeLess })), e.set(i.subarray(t), r.offset), n - t
                                )
                            }
                            if (t < 0) throw new Error('Cannot peek from a negative offset in a stream')
                        }
                        if (r.length > 0) {
                            try {
                                n = await this.streamReader.peek(e, r.offset, r.length)
                            } catch (e) {
                                if (t && t.mayBeLess && e instanceof i.EndOfStreamError) return 0
                                throw e
                            }
                            if (!r.mayBeLess && n < r.length) throw new i.EndOfStreamError()
                        }
                        return n
                    }
                    async ignore(e) {
                        const t = Math.min(256e3, e),
                            r = new Uint8Array(t)
                        let n = 0
                        for (; n < e;) {
                            const i = e - n,
                                o = await this.readBuffer(r, { length: Math.min(t, i) })
                            if (o < 0) return o
                            n += o
                        }
                        return n
                    }
                }
                t.ReadStreamTokenizer = o
            },
            2055: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.fromBuffer = t.fromStream = t.EndOfStreamError = void 0)
                const n = r(6391),
                    i = r(421)
                var o = r(4682)
                Object.defineProperty(t, 'EndOfStreamError', {
                    enumerable: !0,
                    get: function () {
                        return o.EndOfStreamError
                    }
                }),
                    (t.fromStream = function (e, t) {
                        return (t = t || {}), new n.ReadStreamTokenizer(e, t)
                    }),
                    (t.fromBuffer = function (e, t) {
                        return new i.BufferTokenizer(e, t)
                    })
            },
            3358: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.fromStream = t.fromBuffer = t.EndOfStreamError = t.fromFile = void 0)
                const n = r(6283),
                    i = r(2055)
                var o = r(1916)
                Object.defineProperty(t, 'fromFile', {
                    enumerable: !0,
                    get: function () {
                        return o.fromFile
                    }
                })
                var s = r(2055)
                Object.defineProperty(t, 'EndOfStreamError', {
                    enumerable: !0,
                    get: function () {
                        return s.EndOfStreamError
                    }
                }),
                    Object.defineProperty(t, 'fromBuffer', {
                        enumerable: !0,
                        get: function () {
                            return s.fromBuffer
                        }
                    }),
                    (t.fromStream = async function (e, t) {
                        if (((t = t || {}), e.path)) {
                            const r = await n.stat(e.path)
                                ; (t.path = e.path), (t.size = r.size)
                        }
                        return i.fromStream(e, t)
                    })
            },
            7744: (e, t, r) => {
                'use strict'
                var n = r(692).lW
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.AnsiStringType =
                        t.StringType =
                        t.BufferType =
                        t.Uint8ArrayType =
                        t.IgnoreType =
                        t.Float80_LE =
                        t.Float80_BE =
                        t.Float64_LE =
                        t.Float64_BE =
                        t.Float32_LE =
                        t.Float32_BE =
                        t.Float16_LE =
                        t.Float16_BE =
                        t.INT64_BE =
                        t.UINT64_BE =
                        t.INT64_LE =
                        t.UINT64_LE =
                        t.INT32_LE =
                        t.INT32_BE =
                        t.INT24_BE =
                        t.INT24_LE =
                        t.INT16_LE =
                        t.INT16_BE =
                        t.INT8 =
                        t.UINT32_BE =
                        t.UINT32_LE =
                        t.UINT24_BE =
                        t.UINT24_LE =
                        t.UINT16_BE =
                        t.UINT16_LE =
                        t.UINT8 =
                        void 0)
                const i = r(7467)
                function o(e) {
                    return new DataView(e.buffer, e.byteOffset)
                }
                ; (t.UINT8 = { len: 1, get: (e, t) => o(e).getUint8(t), put: (e, t, r) => (o(e).setUint8(t, r), t + 1) }),
                    (t.UINT16_LE = {
                        len: 2,
                        get: (e, t) => o(e).getUint16(t, !0),
                        put: (e, t, r) => (o(e).setUint16(t, r, !0), t + 2)
                    }),
                    (t.UINT16_BE = {
                        len: 2,
                        get: (e, t) => o(e).getUint16(t),
                        put: (e, t, r) => (o(e).setUint16(t, r), t + 2)
                    }),
                    (t.UINT24_LE = {
                        len: 3,
                        get(e, t) {
                            const r = o(e)
                            return r.getUint8(t) + (r.getUint16(t + 1, !0) << 8)
                        },
                        put(e, t, r) {
                            const n = o(e)
                            return n.setUint8(t, 255 & r), n.setUint16(t + 1, r >> 8, !0), t + 3
                        }
                    }),
                    (t.UINT24_BE = {
                        len: 3,
                        get(e, t) {
                            const r = o(e)
                            return (r.getUint16(t) << 8) + r.getUint8(t + 2)
                        },
                        put(e, t, r) {
                            const n = o(e)
                            return n.setUint16(t, r >> 8), n.setUint8(t + 2, 255 & r), t + 3
                        }
                    }),
                    (t.UINT32_LE = {
                        len: 4,
                        get: (e, t) => o(e).getUint32(t, !0),
                        put: (e, t, r) => (o(e).setUint32(t, r, !0), t + 4)
                    }),
                    (t.UINT32_BE = {
                        len: 4,
                        get: (e, t) => o(e).getUint32(t),
                        put: (e, t, r) => (o(e).setUint32(t, r), t + 4)
                    }),
                    (t.INT8 = { len: 1, get: (e, t) => o(e).getInt8(t), put: (e, t, r) => (o(e).setInt8(t, r), t + 1) }),
                    (t.INT16_BE = { len: 2, get: (e, t) => o(e).getInt16(t), put: (e, t, r) => (o(e).setInt16(t, r), t + 2) }),
                    (t.INT16_LE = {
                        len: 2,
                        get: (e, t) => o(e).getInt16(t, !0),
                        put: (e, t, r) => (o(e).setInt16(t, r, !0), t + 2)
                    }),
                    (t.INT24_LE = {
                        len: 3,
                        get(e, r) {
                            const n = t.UINT24_LE.get(e, r)
                            return n > 8388607 ? n - 16777216 : n
                        },
                        put(e, t, r) {
                            const n = o(e)
                            return n.setUint8(t, 255 & r), n.setUint16(t + 1, r >> 8, !0), t + 3
                        }
                    }),
                    (t.INT24_BE = {
                        len: 3,
                        get(e, r) {
                            const n = t.UINT24_BE.get(e, r)
                            return n > 8388607 ? n - 16777216 : n
                        },
                        put(e, t, r) {
                            const n = o(e)
                            return n.setUint16(t, r >> 8), n.setUint8(t + 2, 255 & r), t + 3
                        }
                    }),
                    (t.INT32_BE = { len: 4, get: (e, t) => o(e).getInt32(t), put: (e, t, r) => (o(e).setInt32(t, r), t + 4) }),
                    (t.INT32_LE = {
                        len: 4,
                        get: (e, t) => o(e).getInt32(t, !0),
                        put: (e, t, r) => (o(e).setInt32(t, r, !0), t + 4)
                    }),
                    (t.UINT64_LE = {
                        len: 8,
                        get: (e, t) => o(e).getBigUint64(t, !0),
                        put: (e, t, r) => (o(e).setBigUint64(t, r, !0), t + 8)
                    }),
                    (t.INT64_LE = {
                        len: 8,
                        get: (e, t) => o(e).getBigInt64(t, !0),
                        put: (e, t, r) => (o(e).setBigInt64(t, r, !0), t + 8)
                    }),
                    (t.UINT64_BE = {
                        len: 8,
                        get: (e, t) => o(e).getBigUint64(t),
                        put: (e, t, r) => (o(e).setBigUint64(t, r), t + 8)
                    }),
                    (t.INT64_BE = {
                        len: 8,
                        get: (e, t) => o(e).getBigInt64(t),
                        put: (e, t, r) => (o(e).setBigInt64(t, r), t + 8)
                    }),
                    (t.Float16_BE = {
                        len: 2,
                        get(e, t) {
                            return i.read(e, t, !1, 10, this.len)
                        },
                        put(e, t, r) {
                            return i.write(e, r, t, !1, 10, this.len), t + this.len
                        }
                    }),
                    (t.Float16_LE = {
                        len: 2,
                        get(e, t) {
                            return i.read(e, t, !0, 10, this.len)
                        },
                        put(e, t, r) {
                            return i.write(e, r, t, !0, 10, this.len), t + this.len
                        }
                    }),
                    (t.Float32_BE = {
                        len: 4,
                        get: (e, t) => o(e).getFloat32(t),
                        put: (e, t, r) => (o(e).setFloat32(t, r), t + 4)
                    }),
                    (t.Float32_LE = {
                        len: 4,
                        get: (e, t) => o(e).getFloat32(t, !0),
                        put: (e, t, r) => (o(e).setFloat32(t, r, !0), t + 4)
                    }),
                    (t.Float64_BE = {
                        len: 8,
                        get: (e, t) => o(e).getFloat64(t),
                        put: (e, t, r) => (o(e).setFloat64(t, r), t + 8)
                    }),
                    (t.Float64_LE = {
                        len: 8,
                        get: (e, t) => o(e).getFloat64(t, !0),
                        put: (e, t, r) => (o(e).setFloat64(t, r, !0), t + 8)
                    }),
                    (t.Float80_BE = {
                        len: 10,
                        get(e, t) {
                            return i.read(e, t, !1, 63, this.len)
                        },
                        put(e, t, r) {
                            return i.write(e, r, t, !1, 63, this.len), t + this.len
                        }
                    }),
                    (t.Float80_LE = {
                        len: 10,
                        get(e, t) {
                            return i.read(e, t, !0, 63, this.len)
                        },
                        put(e, t, r) {
                            return i.write(e, r, t, !0, 63, this.len), t + this.len
                        }
                    }),
                    (t.IgnoreType = class {
                        constructor(e) {
                            this.len = e
                        }
                        get(e, t) { }
                    }),
                    (t.Uint8ArrayType = class {
                        constructor(e) {
                            this.len = e
                        }
                        get(e, t) {
                            return e.subarray(t, t + this.len)
                        }
                    }),
                    (t.BufferType = class {
                        constructor(e) {
                            this.len = e
                        }
                        get(e, t) {
                            return n.from(e.subarray(t, t + this.len))
                        }
                    }),
                    (t.StringType = class {
                        constructor(e, t) {
                            ; (this.len = e), (this.encoding = t)
                        }
                        get(e, t) {
                            return n.from(e).toString(this.encoding, t, t + this.len)
                        }
                    })
                class s {
                    constructor(e) {
                        this.len = e
                    }
                    static decode(e, t, r) {
                        let n = ''
                        for (let i = t; i < r; ++i) n += s.codePointToString(s.singleByteDecoder(e[i]))
                        return n
                    }
                    static inRange(e, t, r) {
                        return t <= e && e <= r
                    }
                    static codePointToString(e) {
                        return e <= 65535
                            ? String.fromCharCode(e)
                            : ((e -= 65536), String.fromCharCode(55296 + (e >> 10), 56320 + (1023 & e)))
                    }
                    static singleByteDecoder(e) {
                        if (s.inRange(e, 0, 127)) return e
                        const t = s.windows1252[e - 128]
                        if (null === t) throw Error('invaliding encoding')
                        return t
                    }
                    get(e, t = 0) {
                        return s.decode(e, t, t + this.len)
                    }
                }
                ; (t.AnsiStringType = s),
                    (s.windows1252 = [
                        8364, 129, 8218, 402, 8222, 8230, 8224, 8225, 710, 8240, 352, 8249, 338, 141, 381, 143, 144, 8216, 8217,
                        8220, 8221, 8226, 8211, 8212, 732, 8482, 353, 8250, 339, 157, 382, 376, 160, 161, 162, 163, 164, 165, 166,
                        167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187,
                        188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208,
                        209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229,
                        230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250,
                        251, 252, 253, 254, 255
                    ])
            },
            5043: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.assertGetChat = t.assertFindChat = t.InvalidChat = void 0)
                const n = r(4882),
                    i = r(9240)
                class o extends i.WPPError {
                    constructor(e) {
                        super('chat_not_found', `Chat not found for ${e}`), (this.id = e)
                    }
                }
                ; (t.InvalidChat = o),
                    (t.assertFindChat = async function (e) {
                        const t = await n.chat.find(e)
                        if (!t) throw new o(e)
                        return t
                    }),
                    (t.assertGetChat = function (e) {
                        const t = n.chat.get(e)
                        if (!t) throw new o(e)
                        return t
                    })
            },
            380: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.assertColor = t.InvalidColor = void 0)
                const n = r(9240)
                class i extends n.WPPError {
                    constructor(e) {
                        super('invalid_color', `Invalid Color value for ${e}`), (this.color = e)
                    }
                }
                ; (t.InvalidColor = i),
                    (t.assertColor = function (e) {
                        let t
                        if ('number' == typeof e) t = e > 0 ? e : 4294967295 + Number(e) + 1
                        else {
                            if ('string' != typeof e) throw new i(e)
                            {
                                let r = e.trim().replace('#', '')
                                r.length <= 6 && (r = 'FF' + r.padStart(6, '0')), (t = parseInt(r, 16))
                            }
                        }
                        return t
                    })
            },
            3052: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.assertIsBusiness = t.NotIsBusinessError = void 0)
                const n = r(9240),
                    i = r(2117)
                class o extends n.WPPError {
                    constructor() {
                        super('is_not_business', 'This account is not a business version')
                    }
                }
                ; (t.NotIsBusinessError = o),
                    (t.assertIsBusiness = function () {
                        if (!i.Conn.isSMB) throw new o()
                    })
            },
            4617: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.assertGetProduct = t.InvalidProduct = void 0)
                const n = r(9240),
                    i = r(2117)
                class o extends n.WPPError {
                    constructor(e) {
                        super('product_not_found', `Product not found for ${e}`), (this.id = e)
                    }
                }
                ; (t.InvalidProduct = o),
                    (t.assertGetProduct = async function (e) {
                        const t = (
                            await i.CatalogStore.findProduct({ catalogWid: i.UserPrefs.getMaybeMeUser(), productId: e })
                        )[0].msgProductCollection._index[e]
                        if (!t) throw new o(e)
                        return t
                    })
            },
            439: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.assertWid = t.InvalidWid = void 0)
                const n = r(9240)
                class i extends n.WPPError {
                    constructor(e) {
                        super('invalid_wid', `Invalid WID value for ${e}`), (this.id = e)
                    }
                }
                ; (t.InvalidWid = i),
                    (t.assertWid = function (e) {
                        const t = (0, n.createWid)(e)
                        if (!t) throw new i(e)
                        return t
                    })
            },
            655: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    i(r(5043), t),
                    i(r(380), t),
                    i(r(3052), t),
                    i(r(4617), t),
                    i(r(439), t)
            },
            3682: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.defaultSendMessageOptions = void 0),
                    (t.defaultSendMessageOptions = {
                        createChat: !1,
                        detectMentioned: !0,
                        linkPreview: !0,
                        markIsRead: !0,
                        waitForAck: !0
                    })
            },
            7919: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    r(2401),
                    r(7265),
                    r(6698),
                    r(1534),
                    r(7244),
                    r(2374),
                    r(1089),
                    r(9621)
            },
            2401: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117),
                    c = r(6700),
                    l = r(6219)
                a.onInjected(() =>
                    (function () {
                        function e(e) {
                            if (e.ack < 2 || 'sender' === e.ackString) return
                            const t = e.from,
                                r = e.participant || void 0,
                                n = e.from,
                                i = !e.recipient || u.UserPrefs.getMeUser().equals(e.recipient)
                            if (!i) return
                            const o = e.externalIds.map(
                                (t) => new u.MsgKey({ id: t, remote: n, fromMe: i, participant: e.participant })
                            )
                            s.internalEv.emit('chat.msg_ack_change', { ack: e.ack, chat: t, sender: r, ids: o })
                        }
                        u.MsgStore.on('change:ack', (e) => {
                            1 === e.ack &&
                                queueMicrotask(() => {
                                    s.internalEv.emit('chat.msg_ack_change', { ack: e.ack, chat: e.to, ids: [e.id] })
                                })
                        }),
                            (0, c.wrapModuleFunction)(l.handleChatSimpleReceipt, (t, ...r) => {
                                const [n] = r
                                return (
                                    queueMicrotask(() => {
                                        e(n)
                                    }),
                                    t(...r)
                                )
                            }),
                            (0, c.wrapModuleFunction)(l.handleGroupSimpleReceipt, (t, ...r) => {
                                const [n] = r
                                return (
                                    queueMicrotask(() => {
                                        e(n)
                                    }),
                                    t(...r)
                                )
                            }),
                            (0, c.wrapModuleFunction)(l.handleStatusSimpleReceipt, (t, ...r) => {
                                const [n] = r
                                return (
                                    queueMicrotask(() => {
                                        e(n)
                                    }),
                                    t(...r)
                                )
                            })
                    })()
                )
            },
            7265: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117)
                a.onInjected(() => {
                    u.ChatStore.on('change:active', (e, t) => {
                        t &&
                            queueMicrotask(() => {
                                s.internalEv.emit('chat.active_chat', e)
                            })
                    })
                })
            },
            6698: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(5748),
                    a = r(8927),
                    u = o(r(1250)),
                    c = r(2117),
                    l = r(6219)
                u.onInjected(() =>
                    (function () {
                        c.MsgStore.on('add', (e) => {
                            e.isNewMsg &&
                                e.isLive &&
                                queueMicrotask(() => {
                                    a.internalEv.emit('chat.live_location_start', {
                                        id: e.sender,
                                        msgId: e.id,
                                        chat: e.chat.id,
                                        lat: e.lat,
                                        lng: e.lng,
                                        accuracy: e.accuracy,
                                        speed: e.speed,
                                        degrees: e.degrees,
                                        shareDuration: e.shareDuration
                                    }),
                                        c.LiveLocationStore.update(e.chat.id)
                                            .then((e) => {
                                                e.startViewingMap()
                                            })
                                            .catch(() => null)
                                })
                        }),
                            a.internalEv.once('conn.main_ready', () => {
                                c.ChatStore.getModelsArray()
                                    .slice(0, s.config.liveLocationLimit)
                                    .forEach((e) => {
                                        c.LiveLocationStore.update(e.id)
                                            .then((e) => {
                                                e.startViewingMap()
                                            })
                                            .catch(() => null)
                                    })
                            })
                        const e = c.LiveLocationStore.handle
                        c.LiveLocationStore.handle = (t) => {
                            for (const e of t)
                                'update' !== (r = e).type
                                    ? 'disable' !== r.type ||
                                    a.internalEv.emit('chat.live_location_end', { id: r.jid, chat: r.chat, seq: r.seq })
                                    : a.internalEv.emit('chat.live_location_update', {
                                        id: r.jid,
                                        lastUpdated: (0, l.unixTime)() - r.elapsed,
                                        elapsed: r.elapsed,
                                        lat: r.lat,
                                        lng: r.lng,
                                        accuracy: r.accuracy,
                                        speed: r.speed,
                                        degrees: r.degrees,
                                        comment: r.body
                                    })
                            var r
                            return e.call(e, t)
                        }
                    })()
                )
            },
            1534: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117)
                a.onInjected(() => {
                    u.MsgStore.on('add', (e) => {
                        e.isNewMsg &&
                            queueMicrotask(() => {
                                'ciphertext' === e.type &&
                                    e.once('change:type', () => {
                                        queueMicrotask(() => {
                                            s.internalEv.emit('chat.new_message', e)
                                        })
                                    }),
                                    s.internalEv.emit('chat.new_message', e)
                            })
                    })
                })
            },
            7244: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(6700),
                    c = r(6219),
                    l = r(313)
                a.onInjected(() => {
                    ; (0, u.wrapModuleFunction)(c.upsertVotes, async (e, ...t) => {
                        const [r] = t
                        for (const e of r)
                            try {
                                const t = await (0, l.getMessageById)(e.parentMsgKey),
                                    r = []
                                for (const n of e.selectedOptionLocalIds) r[n] = t.pollOptions.filter((e) => e.localId == n)[0]
                                s.internalEv
                                    .emitAsync('chat.poll_response', {
                                        msgId: e.parentMsgKey,
                                        chatId: e.parentMsgKey.remote,
                                        selectedOptions: r,
                                        timestamp: e.senderTimestampMs,
                                        sender: e.sender
                                    })
                                    .catch(() => null)
                            } catch (e) { }
                        return e(...t)
                    })
                })
            },
            2374: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(8927),
                    i = r(2117)
                n.internalEv.on('conn.main_ready', async () => {
                    const e = i.ChatStore.map((e) => e.presence.subscribe())
                    await Promise.all(e),
                        i.PresenceStore.on('change:chatstate.type', (e) => {
                            var t
                            const r = i.PresenceStore.getModelsArray().find((t) => t.chatstate === e)
                            r &&
                                r.hasData &&
                                (null === (t = r.chatstate) || void 0 === t ? void 0 : t.type) &&
                                queueMicrotask(() => {
                                    var e, t
                                    const o = i.ContactStore.get(r.id),
                                        s = {
                                            id: r.id,
                                            isOnline: r.isOnline,
                                            isGroup: r.isGroup,
                                            isUser: r.isUser,
                                            shortName: o ? o.formattedShortName : '',
                                            state: null === (e = r.chatstate) || void 0 === e ? void 0 : e.type,
                                            t: Date.now()
                                        }
                                    r.isUser && (s.isContact = !(null === (t = r.chatstate) || void 0 === t ? void 0 : t.deny)),
                                        r.isGroup &&
                                        (s.participants = r.chatstates
                                            .getModelsArray()
                                            .filter((e) => !!e.type)
                                            .map((e) => {
                                                const t = i.ContactStore.get(e.id)
                                                return { id: e.id.toString(), state: e.type, shortName: t ? t.formattedShortName : '' }
                                            })),
                                        n.internalEv.emit('chat.presence_change', s)
                                })
                        })
                })
            },
            1089: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = r(9240),
                    u = o(r(1250)),
                    c = r(2117),
                    l = r(6700),
                    d = r(6219)
                u.onInjected(() => {
                    ; (0, l.wrapModuleFunction)(d.createOrUpdateReactions, (e, ...t) => {
                        const [r] = t
                        for (const e of r)
                            try {
                                s.internalEv.emitAsync('chat.new_reaction', {
                                    id: c.MsgKey.fromString(e.msgKey),
                                    orphan: e.orphan,
                                    orphanReason: e.orphanReason,
                                    msgId: c.MsgKey.fromString(e.parentMsgKey),
                                    reactionText: e.reactionText,
                                    read: e.read,
                                    sender: (0, a.createWid)(e.senderUserJid),
                                    timestamp: e.timestamp
                                })
                            } catch (e) { }
                        return e(...t)
                    })
                })
            },
            9621: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117)
                a.onInjected(() =>
                    (function () {
                        const e = u.MsgStore.processMultipleMessages,
                            t = ['revoke', 'sender_revoke', 'admin_revoke']
                        u.MsgStore.processMultipleMessages = (r, n, ...i) =>
                            new Promise((o, a) => {
                                try {
                                    for (const e of n)
                                        e.isNewMsg &&
                                            'protocol' === e.type &&
                                            t.includes(e.subtype) &&
                                            s.internalEv.emit('chat.msg_revoke', {
                                                author: e.author,
                                                from: e.from,
                                                id: e.id,
                                                refId: e.protocolMessageKey,
                                                to: e.to,
                                                type: e.subtype
                                            })
                                } catch (e) { }
                                e.call(u.MsgStore, r, n, ...i).then(o, a)
                            })
                    })()
                )
            },
            3635: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.unarchive = t.archive = void 0)
                const n = r(655),
                    i = r(9240),
                    o = r(6219)
                async function s(e, t = !0) {
                    const r = (0, n.assertWid)(e),
                        s = (0, n.assertGetChat)(r)
                    if (s.archive === t)
                        throw new i.WPPError(
                            (t ? 'archive' : 'unarchive') + '_error',
                            `The chat ${r.toString()} is already ${t ? 'archived' : 'unarchived'}`,
                            { wid: r, archive: t }
                        )
                    return await (0, o.setArchive)(s, t), { wid: r, archive: t }
                }
                ; (t.archive = s),
                    (t.unarchive = async function (e) {
                        return s(e, !1)
                    })
            },
            5910: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.canMarkPlayed = void 0)
                const n = r(2117),
                    i = r(6219),
                    o = r(6914)
                t.canMarkPlayed = async function (e) {
                    e instanceof n.MsgModel || 'string' == typeof e || 'function' != typeof e.toString || (e = e.toString())
                    const t = e instanceof n.MsgModel ? e : await (0, o.getMessageById)(e.toString())
                    return (0, i.canMarkPlayed)(t)
                }
            },
            2056: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.canMute = void 0)
                const n = r(655)
                t.canMute = function (e) {
                    const t = (0, n.assertWid)(e)
                    return (0, n.assertGetChat)(t).mute.canMute()
                }
            },
            4034: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.canReply = void 0)
                const n = r(2117),
                    i = r(6219),
                    o = r(6914)
                t.canReply = async function (e) {
                    e instanceof n.MsgModel || 'string' == typeof e || 'function' != typeof e.toString || (e = e.toString())
                    const t = e instanceof n.MsgModel ? e : await (0, o.getMessageById)(e.toString())
                    return (0, i.canReplyMsg)(t)
                }
            },
            7227: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.clear = void 0)
                const n = r(655),
                    i = r(6219)
                t.clear = async function (e, t = !0) {
                    const r = (0, n.assertWid)(e),
                        o = (0, n.assertGetChat)(r)
                        ; (0, i.sendClear)(o, t)
                    let s = 200
                    return (
                        o.promises.sendClear && (s = (await o.promises.sendClear.catch(() => ({ status: 500 }))).status || s),
                        { wid: r, status: s, keepStarred: t }
                    )
                }
            },
            3310: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.delete = void 0)
                const n = r(655),
                    i = r(6219)
                t.delete = async function (e) {
                    const t = (0, n.assertWid)(e),
                        r = (0, n.assertGetChat)(t)
                        ; (0, i.sendDelete)(r)
                    let o = 200
                    return (
                        r.promises.sendDelete && (o = (await r.promises.sendDelete.catch(() => ({ status: 500 }))).status || o),
                        { wid: t, status: o }
                    )
                }
            },
            1803: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.deleteMessage = void 0)
                const n = r(655),
                    i = r(2117),
                    o = r(3238),
                    s = r(313)
                t.deleteMessage = async function (e, t, r = !1, a = !1) {
                    const u = (0, n.assertGetChat)(e)
                    let c = !1
                    Array.isArray(t) || ((c = !0), (t = [t]))
                    const l = await (0, s.getMessageById)(t),
                        d = []
                    for (const e of l) {
                        let t = o.SendMsgResult.ERROR_UNKNOWN,
                            n = !1,
                            s = !1
                        const c = e.isSentByMe
                        if (e.type === o.MSG_TYPE.REVOKED && a) (t = o.SendMsgResult.ERROR_UNKNOWN), (n = !0)
                        else if (a) {
                            if (
                                ('list' === e.type && (e.__x_isUserCreatedType = !0),
                                    i.Cmd.sendRevokeMsgs(u, [e], { clearMedia: r }),
                                    u.promises.sendRevokeMsgs)
                            ) {
                                const e = await u.promises.sendRevokeMsgs
                                Array.isArray(e) && (t = e[0])
                            }
                            n = e.isRevokedByMe
                        } else {
                            if ((i.Cmd.sendDeleteMsgs(u, [e], r), u.promises.sendDeleteMsgs)) {
                                const e = await u.promises.sendDeleteMsgs
                                Array.isArray(e) && (t = e[0])
                            }
                            s = Boolean(u.msgs.get(e.id))
                        }
                        d.push({ id: e.id.toString(), sendMsgResult: t, isRevoked: n, isDeleted: s, isSentByMe: c })
                    }
                    return c ? d[0] : d
                }
            },
            7111: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.downloadMedia = void 0)
                const n = r(9240),
                    i = r(2117),
                    o = r(313)
                t.downloadMedia = async function e(t) {
                    var r
                    const s = await (0, o.getMessageById)(t)
                    if (!s.mediaData)
                        throw new n.WPPError('message_not_contains_media', `Message ${t} not contains media`, { id: t })
                    await s.downloadMedia({ downloadEvenIfExpensive: !0, rmrReason: 1, isUserInitiated: !0 })
                    let a = null
                    if (
                        (s.mediaData.filehash && (a = i.MediaBlobCache.get(s.mediaData.filehash)),
                            !a && s.mediaData.mediaBlob && (a = s.mediaData.mediaBlob.forceToBlob()),
                            !a && 'VIDEO' === (null === (r = s.mediaObject) || void 0 === r ? void 0 : r.type))
                    )
                        try {
                            return (s.type = 'document'), (s.mediaObject.type = 'DOCUMENT'), await e(t)
                        } finally {
                            ; (s.type = 'video'), (s.mediaObject.type = 'VIDEO')
                        }
                    if (!a) throw { error: !0, code: 'media_not_found', message: 'Media not found' }
                    return a
                }
            },
            1795: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.editMessage = void 0)
                const n = r(9240),
                    i = r(6219),
                    o = r(4057),
                    s = r(313)
                t.editMessage = async function (e, t, r = {}) {
                    var a
                    r = Object.assign(Object.assign({}, o.defaultSendMessageOptions), r)
                    const u = await (0, s.getMessageById)(e)
                    if (!(0, i.canEditMessage)(u)) throw new n.WPPError('edit_message_error', 'Cannot edit this message')
                    let c = { type: 'protocol', subtype: 'message_edit', protocolMessageKey: u.id, body: t.trim() }
                    return (
                        (c = await (0, s.prepareRawMessage)(u.chat, c, r)),
                        (c.latestEditMsgKey = c.id),
                        (c.latestEditSenderTimestampMs = c.t),
                        await (0, s.sendRawMessage)(null === (a = u.chat) || void 0 === a ? void 0 : a.id, c, r)
                    )
                }
            },
            2827: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.find = void 0)
                const n = r(655),
                    i = r(2117),
                    o = r(6219)
                t.find = async function (e) {
                    const t = (0, n.assertWid)(e),
                        r = await (0, o.findChat)(t)
                    return r.isGroup && (await i.GroupMetadataStore.find(r.id)), r
                }
            },
            546: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.forwardMessage = void 0)
                const n = r(655),
                    i = r(4057)
                t.forwardMessage = async function (e, t, r = {}) {
                    const o = await (0, n.assertFindChat)(e),
                        s = await (0, i.getMessageById)(t)
                    return await o.forwardMessages([s], r.multicast, r.displayCaptionText)
                }
            },
            9845: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.generateMessageID = void 0)
                const n = r(655),
                    i = r(2117),
                    o = r(6219)
                t.generateMessageID = function (e) {
                    const t = i.UserPrefs.getMaybeMeUser()
                    let r, s
                    return (
                        (r = e instanceof i.Wid ? e : e instanceof i.ChatModel ? e.id : (0, n.assertWid)(e)),
                        r.isGroup() && (s = i.WidFactory.toUserWid(t)),
                        new i.MsgKey({ from: t, to: r, id: (0, o.randomMessageId)(), participant: s, selfDir: 'out' })
                    )
                }
            },
            7769: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.get = void 0)
                const n = r(655),
                    i = r(2117)
                t.get = function (e) {
                    const t = (0, n.assertWid)(e)
                    return i.ChatStore.get(t)
                }
            },
            7562: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getActiveChat = void 0)
                const n = r(2117)
                t.getActiveChat = function () {
                    return n.ChatStore.findFirst((e) => e.active)
                }
            },
            8062: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getLastSeen = void 0)
                const n = r(655),
                    i = r(2117)
                t.getLastSeen = async function (e) {
                    const t = (0, n.assertWid)(e),
                        r = await i.ChatStore.get(t)
                    return (
                        !!r &&
                        (r.presence.hasData || (await r.presence.subscribe(), await new Promise((e) => setTimeout(e, 100))),
                            r.presence.chatstate.t || !1)
                    )
                }
            },
            4509: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getMessageACK = void 0)
                const n = r(2117),
                    i = r(4057)
                t.getMessageACK = async function (e) {
                    const t = await (0, i.getMessageById)(e),
                        r = await n.MsgInfoStore.find(t.id),
                        o = new Map(),
                        s = (e, t) => {
                            const r = e.id.toString(),
                                n = o.get(r) || { id: r, wid: e.id }
                                ; (n[t] = e.t), o.set(r, n)
                        }
                    return (
                        null == r || r.delivery.forEach((e) => s(e, 'deliveredAt')),
                        null == r || r.read.forEach((e) => s(e, 'readAt')),
                        null == r || r.played.forEach((e) => s(e, 'playedAt')),
                        {
                            ack: t.ack,
                            fromMe: t.id.fromMe,
                            deliveryRemaining: (null == r ? void 0 : r.deliveryRemaining) || 0,
                            readRemaining: (null == r ? void 0 : r.readRemaining) || 0,
                            playedRemaining: (null == r ? void 0 : r.playedRemaining) || 0,
                            participants: Array.from(o.values())
                        }
                    )
                }
            },
            6914: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__importDefault) ||
                    function (e) {
                        return e && e.__esModule ? e : { default: e }
                    }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getMessageById = void 0)
                const i = n(r(840)),
                    o = r(655),
                    s = r(9240),
                    a = r(2117),
                    u = r(6219),
                    c = (0, i.default)('WA-JS:message:getMessageById')
                t.getMessageById = async function (e) {
                    let t = !1
                    Array.isArray(e) || ((t = !0), (e = [e]))
                    const r = e.map((e) => a.MsgKey.fromString(e.toString())),
                        n = []
                    for (const e of r) {
                        let t = a.MsgStore.get(e)
                        if (!t) {
                            const r = (0, o.assertGetChat)(e.remote)
                            if (((t = r.msgs.get(e)), !t)) {
                                c(`searching remote message with id ${e.toString()}`)
                                const n = (0, u.getSearchContext)(r, e)
                                await n.collection.loadAroundPromise, (t = r.msgs.get(e) || n.collection.get(e))
                            }
                        }
                        if (!t)
                            throw (
                                (c(`message id ${e.toString()} not found`),
                                    new s.WPPError('msg_not_found', `Message ${e.toString()} not found`, { id: e.toString() }))
                            )
                        n.push(t)
                    }
                    return t ? n[0] : n
                }
            },
            6946: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getMessages = void 0)
                const n = r(655),
                    i = r(3073),
                    o = r(2117),
                    s = r(6219)
                t.getMessages = async function (e, t = {}) {
                    var r
                    const a = (0, n.assertGetChat)(e)
                    let u = t.count || 20
                    const c = 'after' === t.direction ? 'after' : 'before',
                        l = t.id || (null === (r = a.lastReceivedKey) || void 0 === r ? void 0 : r.toString())
                    if (t.onlyUnread) {
                        if (!a.hasUnread) return []
                        const e = a.unreadCount < 0 ? 2 : a.unreadCount
                        u = u < 0 ? e : Math.min(u, e)
                    }
                    ; -1 === u && (0, i.isMultiDevice)() && (u = 1 / 0), !t.id && l && u--
                    const d = l ? o.MsgKey.fromString(l) : { remote: a.id }
                        ; (d.count = u), (d.direction = c)
                    let f = []
                    if ('all' === t.media) {
                        const { messages: e } = await (0, s.msgFindQuery)('media', d)
                        f = e
                    } else if ('image' === t.media) {
                        const { messages: e } = await (0, s.msgFindQuery)('media', d)
                        for (const t of e) 'image' === t.type && f.push(t)
                    } else
                        void 0 !== t.media
                            ? ((d.media = t.media), (f = await (0, s.msgFindQuery)('media', d)))
                            : (f = await (0, s.msgFindQuery)(c, d))
                    if (!t.id && l) {
                        const e = o.MsgStore.get(l)
                        e && f.push(e.attributes)
                    }
                    return f
                }
            },
            3095: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getPlatformFromMessage = void 0)
                const n = r(2117)
                t.getPlatformFromMessage = function (e) {
                    e instanceof n.MsgModel || 'string' == typeof e || 'function' != typeof e.toString || (e = e.toString()),
                        e instanceof n.MsgModel && (e = e.id)
                    const t = n.MsgKey.fromString(e.toString())
                    return t.id.length > 21
                        ? 'android'
                        : t.id.startsWith('3A')
                            ? 'iphone'
                            : t.id.startsWith('3EB0')
                                ? 'web'
                                : 'unknown'
                }
            },
            5590: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getReactions = void 0)
                const n = r(9240),
                    i = r(6219)
                t.getReactions = async function (e) {
                    const t = await (0, i.getReactions)(e),
                        r = []
                    for (const e of t.reactions) {
                        const t = { aggregateEmoji: e.aggregateEmoji, hasReactionByMe: e.hasReactionByMe, senders: [] }
                        for (const r of e.senders)
                            t.senders.push({
                                id: r.msgKey,
                                msgId: r.parentMsgKey,
                                reactionText: r.reactionText,
                                read: r.read,
                                sender: (0, n.createWid)(r.senderUserJid),
                                orphan: r.orphan,
                                timestamp: r.timestamp
                            })
                        r.push(t)
                    }
                    return {
                        reactionByMe: t.reactionByMe
                            ? {
                                id: t.reactionByMe.msgKey,
                                orphan: t.reactionByMe.orphan,
                                msgId: t.reactionByMe.parentMsgKey,
                                reactionText: t.reactionByMe.reactionText,
                                read: t.reactionByMe.read,
                                senderUserJid: (0, n.createWid)(t.reactionByMe.senderUserJid),
                                timestamp: t.reactionByMe.timestamp
                            }
                            : void 0,
                        reactions: r
                    }
                }
            },
            9365: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getVotes = void 0)
                const n = r(9240),
                    i = r(2117),
                    o = r(6219),
                    s = r(6914)
                t.getVotes = async function (e) {
                    const t = i.MsgKey.fromString(e.toString()),
                        r = await (0, s.getMessageById)(t)
                    if (!r.asPollCreation)
                        throw new n.WPPError('msg_not_found', `Message ${t.toString()} not not a poll`, { id: t.toString() })
                    const a = await (0, o.getVotes)(t),
                        u = { msgId: t, chatId: t.remote, votes: [] }
                    for (const e of a) {
                        const t = { selectedOptions: [], timestamp: e.senderTimestampMs, sender: e.sender }
                        for (const n of e.selectedOptionLocalIds)
                            t.selectedOptions[n] = r.pollOptions.filter((e) => e.localId == n)[0]
                        u.votes.push(t)
                    }
                    return u
                }
            },
            313: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.unmute =
                        t.starMessage =
                        t.sendVCardContactMessage =
                        t.sendTextMessage =
                        t.sendReactionToMessage =
                        t.sendRawMessage =
                        t.sendLocationMessage =
                        t.sendListMessage =
                        t.sendFileMessage =
                        t.sendCreatePollMessage =
                        t.requestPhoneNumber =
                        t.prepareRawMessage =
                        t.prepareMessageButtons =
                        t.prepareLinkPreview =
                        t.unpin =
                        t.pin =
                        t.openChatFromUnread =
                        t.openChatBottom =
                        t.openChatAt =
                        t.mute =
                        t.markPlayed =
                        t.markIsUnread =
                        t.markIsRecording =
                        t.markIsRead =
                        t.markIsPaused =
                        t.markIsComposing =
                        t.list =
                        t.getVotes =
                        t.getReactions =
                        t.getPlatformFromMessage =
                        t.getMessages =
                        t.getMessageById =
                        t.getMessageACK =
                        t.getLastSeen =
                        t.getActiveChat =
                        t.get =
                        t.generateMessageID =
                        t.forwardMessage =
                        t.find =
                        t.editMessage =
                        t.downloadMedia =
                        t.deleteMessage =
                        t.delete =
                        t.clear =
                        t.canReply =
                        t.canMute =
                        t.canMarkPlayed =
                        t.unarchive =
                        t.archive =
                        void 0)
                var n = r(3635)
                Object.defineProperty(t, 'archive', {
                    enumerable: !0,
                    get: function () {
                        return n.archive
                    }
                }),
                    Object.defineProperty(t, 'unarchive', {
                        enumerable: !0,
                        get: function () {
                            return n.unarchive
                        }
                    })
                var i = r(5910)
                Object.defineProperty(t, 'canMarkPlayed', {
                    enumerable: !0,
                    get: function () {
                        return i.canMarkPlayed
                    }
                })
                var o = r(2056)
                Object.defineProperty(t, 'canMute', {
                    enumerable: !0,
                    get: function () {
                        return o.canMute
                    }
                })
                var s = r(4034)
                Object.defineProperty(t, 'canReply', {
                    enumerable: !0,
                    get: function () {
                        return s.canReply
                    }
                })
                var a = r(7227)
                Object.defineProperty(t, 'clear', {
                    enumerable: !0,
                    get: function () {
                        return a.clear
                    }
                })
                var u = r(3310)
                Object.defineProperty(t, 'delete', {
                    enumerable: !0,
                    get: function () {
                        return u.delete
                    }
                })
                var c = r(1803)
                Object.defineProperty(t, 'deleteMessage', {
                    enumerable: !0,
                    get: function () {
                        return c.deleteMessage
                    }
                })
                var l = r(7111)
                Object.defineProperty(t, 'downloadMedia', {
                    enumerable: !0,
                    get: function () {
                        return l.downloadMedia
                    }
                })
                var d = r(1795)
                Object.defineProperty(t, 'editMessage', {
                    enumerable: !0,
                    get: function () {
                        return d.editMessage
                    }
                })
                var f = r(2827)
                Object.defineProperty(t, 'find', {
                    enumerable: !0,
                    get: function () {
                        return f.find
                    }
                })
                var p = r(546)
                Object.defineProperty(t, 'forwardMessage', {
                    enumerable: !0,
                    get: function () {
                        return p.forwardMessage
                    }
                })
                var m = r(9845)
                Object.defineProperty(t, 'generateMessageID', {
                    enumerable: !0,
                    get: function () {
                        return m.generateMessageID
                    }
                })
                var g = r(7769)
                Object.defineProperty(t, 'get', {
                    enumerable: !0,
                    get: function () {
                        return g.get
                    }
                })
                var h = r(7562)
                Object.defineProperty(t, 'getActiveChat', {
                    enumerable: !0,
                    get: function () {
                        return h.getActiveChat
                    }
                })
                var y = r(8062)
                Object.defineProperty(t, 'getLastSeen', {
                    enumerable: !0,
                    get: function () {
                        return y.getLastSeen
                    }
                })
                var b = r(4509)
                Object.defineProperty(t, 'getMessageACK', {
                    enumerable: !0,
                    get: function () {
                        return b.getMessageACK
                    }
                })
                var v = r(6914)
                Object.defineProperty(t, 'getMessageById', {
                    enumerable: !0,
                    get: function () {
                        return v.getMessageById
                    }
                })
                var _ = r(6946)
                Object.defineProperty(t, 'getMessages', {
                    enumerable: !0,
                    get: function () {
                        return _.getMessages
                    }
                })
                var M = r(3095)
                Object.defineProperty(t, 'getPlatformFromMessage', {
                    enumerable: !0,
                    get: function () {
                        return M.getPlatformFromMessage
                    }
                })
                var P = r(5590)
                Object.defineProperty(t, 'getReactions', {
                    enumerable: !0,
                    get: function () {
                        return P.getReactions
                    }
                })
                var w = r(9365)
                Object.defineProperty(t, 'getVotes', {
                    enumerable: !0,
                    get: function () {
                        return w.getVotes
                    }
                })
                var O = r(6106)
                Object.defineProperty(t, 'list', {
                    enumerable: !0,
                    get: function () {
                        return O.list
                    }
                })
                var j = r(8076)
                Object.defineProperty(t, 'markIsComposing', {
                    enumerable: !0,
                    get: function () {
                        return j.markIsComposing
                    }
                })
                var x = r(631)
                Object.defineProperty(t, 'markIsPaused', {
                    enumerable: !0,
                    get: function () {
                        return x.markIsPaused
                    }
                })
                var C = r(9618)
                Object.defineProperty(t, 'markIsRead', {
                    enumerable: !0,
                    get: function () {
                        return C.markIsRead
                    }
                })
                var S = r(959)
                Object.defineProperty(t, 'markIsRecording', {
                    enumerable: !0,
                    get: function () {
                        return S.markIsRecording
                    }
                })
                var I = r(9987)
                Object.defineProperty(t, 'markIsUnread', {
                    enumerable: !0,
                    get: function () {
                        return I.markIsUnread
                    }
                })
                var E = r(6457)
                Object.defineProperty(t, 'markPlayed', {
                    enumerable: !0,
                    get: function () {
                        return E.markPlayed
                    }
                })
                var k = r(2217)
                Object.defineProperty(t, 'mute', {
                    enumerable: !0,
                    get: function () {
                        return k.mute
                    }
                })
                var T = r(8304)
                Object.defineProperty(t, 'openChatAt', {
                    enumerable: !0,
                    get: function () {
                        return T.openChatAt
                    }
                })
                var B = r(8081)
                Object.defineProperty(t, 'openChatBottom', {
                    enumerable: !0,
                    get: function () {
                        return B.openChatBottom
                    }
                })
                var A = r(7277)
                Object.defineProperty(t, 'openChatFromUnread', {
                    enumerable: !0,
                    get: function () {
                        return A.openChatFromUnread
                    }
                })
                var L = r(3936)
                Object.defineProperty(t, 'pin', {
                    enumerable: !0,
                    get: function () {
                        return L.pin
                    }
                }),
                    Object.defineProperty(t, 'unpin', {
                        enumerable: !0,
                        get: function () {
                            return L.unpin
                        }
                    })
                var R = r(6403)
                Object.defineProperty(t, 'prepareLinkPreview', {
                    enumerable: !0,
                    get: function () {
                        return R.prepareLinkPreview
                    }
                })
                var U = r(9276)
                Object.defineProperty(t, 'prepareMessageButtons', {
                    enumerable: !0,
                    get: function () {
                        return U.prepareMessageButtons
                    }
                })
                var F = r(6386)
                Object.defineProperty(t, 'prepareRawMessage', {
                    enumerable: !0,
                    get: function () {
                        return F.prepareRawMessage
                    }
                })
                var D = r(4482)
                Object.defineProperty(t, 'requestPhoneNumber', {
                    enumerable: !0,
                    get: function () {
                        return D.requestPhoneNumber
                    }
                })
                var G = r(3216)
                Object.defineProperty(t, 'sendCreatePollMessage', {
                    enumerable: !0,
                    get: function () {
                        return G.sendCreatePollMessage
                    }
                })
                var N = r(4625)
                Object.defineProperty(t, 'sendFileMessage', {
                    enumerable: !0,
                    get: function () {
                        return N.sendFileMessage
                    }
                })
                var W = r(2393)
                Object.defineProperty(t, 'sendListMessage', {
                    enumerable: !0,
                    get: function () {
                        return W.sendListMessage
                    }
                })
                var z = r(7635)
                Object.defineProperty(t, 'sendLocationMessage', {
                    enumerable: !0,
                    get: function () {
                        return z.sendLocationMessage
                    }
                })
                var $ = r(4348)
                Object.defineProperty(t, 'sendRawMessage', {
                    enumerable: !0,
                    get: function () {
                        return $.sendRawMessage
                    }
                })
                var q = r(4347)
                Object.defineProperty(t, 'sendReactionToMessage', {
                    enumerable: !0,
                    get: function () {
                        return q.sendReactionToMessage
                    }
                })
                var K = r(3436)
                Object.defineProperty(t, 'sendTextMessage', {
                    enumerable: !0,
                    get: function () {
                        return K.sendTextMessage
                    }
                })
                var V = r(7781)
                Object.defineProperty(t, 'sendVCardContactMessage', {
                    enumerable: !0,
                    get: function () {
                        return V.sendVCardContactMessage
                    }
                })
                var H = r(5778)
                Object.defineProperty(t, 'starMessage', {
                    enumerable: !0,
                    get: function () {
                        return H.starMessage
                    }
                })
                var Q = r(6588)
                Object.defineProperty(t, 'unmute', {
                    enumerable: !0,
                    get: function () {
                        return Q.unmute
                    }
                })
            },
            6106: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.list = void 0)
                const n = r(2117)
                t.list = async function (e = {}) {
                    let t = n.ChatStore.getModelsArray().slice()
                    if (
                        (e.onlyUsers && (t = t.filter((e) => e.isUser)),
                            e.onlyGroups && (t = t.filter((e) => e.isGroup)),
                            e.onlyWithUnreadMessage && (t = t.filter((e) => e.hasUnread)),
                            e.withLabels)
                    ) {
                        const r = e.withLabels.map((e) => {
                            const t = n.LabelStore.findFirst((t) => t.name === e)
                            return t ? t.id : e
                        })
                        t = t.filter((e) => {
                            var t
                            return null === (t = e.labels) || void 0 === t ? void 0 : t.some((e) => r.includes(e))
                        })
                    }
                    for (const e of t) e.isGroup && (await n.GroupMetadataStore.find(e.id))
                    return t
                }
            },
            8076: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.markIsComposing = void 0)
                const n = r(655),
                    i = r(2117),
                    o = r(313)
                t.markIsComposing = async function (e, t) {
                    const r = (0, n.assertGetChat)(e)
                    await r.presence.subscribe(),
                        await i.ChatPresence.markComposing(r),
                        r.pausedTimerId && (clearTimeout(r.pausedTimerId), r.unset('pausedTimerId')),
                        t &&
                        (await new Promise((n) => {
                            r.pausedTimerId = setTimeout(() => {
                                ; (0, o.markIsPaused)(e).then(n, n)
                            }, t)
                        }))
                }
            },
            631: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.markIsPaused = void 0)
                const n = r(655),
                    i = r(2117)
                t.markIsPaused = async function (e) {
                    const t = (0, n.assertGetChat)(e)
                    await t.presence.subscribe(), await i.ChatPresence.markPaused(t)
                }
            },
            9618: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.markIsRead = void 0)
                const n = r(655),
                    i = r(6219)
                t.markIsRead = async function (e) {
                    const t = (0, n.assertGetChat)(e),
                        r = t.unreadCount
                    return await (0, i.sendSeen)(t, !1), { wid: t.id, unreadCount: r }
                }
            },
            959: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.markIsRecording = void 0)
                const n = r(655),
                    i = r(2117),
                    o = r(313)
                t.markIsRecording = async function (e, t) {
                    const r = (0, n.assertGetChat)(e)
                    await r.presence.subscribe(),
                        await i.ChatPresence.markRecording(r),
                        t &&
                        (await new Promise((n) => {
                            r.pausedTimerId = setTimeout(() => {
                                ; (0, o.markIsPaused)(e).then(n, n)
                            }, t)
                        }))
                }
            },
            9987: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.markIsUnread = void 0)
                const n = r(655),
                    i = r(6219)
                t.markIsUnread = async function (e) {
                    const t = (0, n.assertGetChat)(e)
                    return await (0, i.markUnread)(t, !0), { wid: t.id }
                }
            },
            6457: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.markPlayed = void 0)
                const n = r(2117),
                    i = r(6219),
                    o = r(6914)
                t.markPlayed = async function (e) {
                    e instanceof n.MsgModel || 'string' == typeof e || 'function' != typeof e.toString || (e = e.toString())
                    const t = e instanceof n.MsgModel ? e : await (0, o.getMessageById)(e.toString())
                    return await (0, i.markPlayed)(t), await (0, o.getMessageById)(e.toString())
                }
            },
            2217: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.mute = void 0)
                const n = r(655),
                    i = r(9240),
                    o = r(6219)
                t.mute = async function (e, t) {
                    const r = (0, n.assertWid)(e),
                        s = (0, n.assertGetChat)(r)
                    let a = 0
                    if ('expiration' in t) a = 'number' == typeof t.expiration ? t.expiration : t.expiration.getTime() / 1e3
                    else {
                        if (!('duration' in t)) throw new i.WPPError('invalid_time_mute', 'Invalid time for mute', { time: t })
                        a = (0, o.unixTime)() + t.duration
                    }
                    if (a < (0, o.unixTime)())
                        throw new i.WPPError('negative_time_mute', 'Negative duration for mute', { time: t })
                    return await s.mute.setMute(a), { wid: r, expiration: s.mute.expiration, isMuted: s.mute.isMuted }
                }
            },
            8304: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.openChatAt = void 0)
                const n = r(655),
                    i = r(2117),
                    o = r(6219),
                    s = r(313)
                t.openChatAt = async function (e, t) {
                    const r = (0, n.assertWid)(e),
                        a = await (0, n.assertFindChat)(r),
                        u = await (0, s.getMessageById)(t),
                        c = (0, o.getSearchContext)(a, u)
                    return await i.Cmd.openChatAt(a, c)
                }
            },
            8081: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.openChatBottom = void 0)
                const n = r(655),
                    i = r(2117)
                t.openChatBottom = async function (e) {
                    const t = (0, n.assertWid)(e),
                        r = await (0, n.assertFindChat)(t)
                    return await i.Cmd.openChatBottom(r)
                }
            },
            7277: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.openChatFromUnread = void 0)
                const n = r(655),
                    i = r(2117)
                t.openChatFromUnread = async function (e) {
                    const t = (0, n.assertWid)(e),
                        r = await (0, n.assertFindChat)(t)
                    return await i.Cmd.openChatFromUnread(r)
                }
            },
            3936: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.unpin = t.pin = void 0)
                const n = r(655),
                    i = r(9240),
                    o = r(6219)
                async function s(e, t = !0) {
                    const r = (0, n.assertWid)(e),
                        s = (0, n.assertGetChat)(r)
                    if (s.pin === t)
                        throw new i.WPPError(
                            (t ? 'pin' : 'unpin') + '_error',
                            `The chat ${r.toString()} is already ${t ? 'pinned' : 'unpinned'}`,
                            { wid: r, pin: t }
                        )
                    return await (0, o.setPin)(s, t), { wid: r, pin: t }
                }
                ; (t.pin = s),
                    (t.unpin = async function (e) {
                        return s(e, !1)
                    })
            },
            6403: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        },
                    s =
                        (this && this.__rest) ||
                        function (e, t) {
                            var r = {}
                            for (var n in e) Object.prototype.hasOwnProperty.call(e, n) && t.indexOf(n) < 0 && (r[n] = e[n])
                            if (null != e && 'function' == typeof Object.getOwnPropertySymbols) {
                                var i = 0
                                for (n = Object.getOwnPropertySymbols(e); i < n.length; i++)
                                    t.indexOf(n[i]) < 0 && Object.prototype.propertyIsEnumerable.call(e, n[i]) && (r[n[i]] = e[n[i]])
                            }
                            return r
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.prepareLinkPreview = void 0)
                const a = r(3149),
                    u = o(r(1250)),
                    c = r(6700),
                    l = r(6219)
                    ; (t.prepareLinkPreview = async function (e, t) {
                        if (!t.linkPreview) return e
                        if (t.linkPreview) {
                            const r = 'object' == typeof t.linkPreview ? t.linkPreview : {},
                                n = 'chat' === e.type ? e.body : ''
                            if (n)
                                try {
                                    const e = (0, l.findFirstWebLink)(n)
                                    if (e) {
                                        const n = await (0, l.fetchLinkPreview)(e)
                                            ; (null == n ? void 0 : n.data) && (t.linkPreview = Object.assign(Object.assign({}, n.data), r))
                                    }
                                } catch (e) { }
                        }
                        return (
                            'object' == typeof t.linkPreview &&
                            ((e.subtype = 'url'), (e = Object.assign(Object.assign({}, e), t.linkPreview))),
                            e
                        )
                    }),
                        u.onReady(() => {
                            ; (0, c.wrapModuleFunction)(l.genMinimalLinkPreview, async (e, ...t) => {
                                const [r] = t
                                return new Promise(async (n) => {
                                    try {
                                        const e = await (0, a.fetchRemoteLinkPreviewData)(r.url)
                                        if (!e) throw new Error(`preview not found for ${r.url}`)
                                        const { imageUrl: t } = e,
                                            i = s(e, ['imageUrl'])
                                        let o = {}
                                        t && (o = await (0, a.generateThumbnailLinkPreviewData)(t).catch(() => null)),
                                            n({ url: r.url, data: Object.assign(Object.assign({}, i), o) })
                                    } catch (r) {
                                        n(e(...t))
                                    }
                                })
                            })
                        })
            },
            9276: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.prepareMessageButtons = void 0)
                const s = o(r(1250)),
                    a = r(2117),
                    u = r(7838),
                    c = r(6700),
                    l = r(6219)
                    ; (t.prepareMessageButtons = function (e, t) {
                        if (!t.buttons) return e
                        if (!Array.isArray(t.buttons)) throw 'Buttons options is not a array'
                        if (
                            ((void 0 !== t.useTemplateButtons && null !== t.useTemplateButtons) ||
                                (t.useTemplateButtons = t.buttons.some((e) => 'phoneNumber' in e || 'url' in e)),
                                t.useTemplateButtons)
                        ) {
                            if (0 === t.buttons.length || t.buttons.length > 5)
                                throw 'Buttons options must have between 1 and 5 options'
                        } else if (0 === t.buttons.length || t.buttons.length > 3)
                            throw 'Buttons options must have between 1 and 3 options'
                        return (
                            (e.title = t.title),
                            (e.footer = t.footer),
                            t.useTemplateButtons
                                ? ((e.isFromTemplate = !0),
                                    (e.buttons = new a.TemplateButtonCollection()),
                                    (e.hydratedButtons = t.buttons.map((e, t) =>
                                        'phoneNumber' in e
                                            ? { index: t, callButton: { displayText: e.text, phoneNumber: e.phoneNumber } }
                                            : 'url' in e
                                                ? { index: t, urlButton: { displayText: e.text, url: e.url } }
                                                : { index: t, quickReplyButton: { displayText: e.text, id: e.id || `${t}` } }
                                    )),
                                    e.buttons.add(
                                        e.hydratedButtons.map((e, t) => {
                                            var r, n, i, o
                                            const s = `${null != e.index ? e.index : t}`
                                            return e.urlButton
                                                ? new a.TemplateButtonModel({
                                                    id: s,
                                                    displayText: null === (r = e.urlButton) || void 0 === r ? void 0 : r.displayText,
                                                    url: null === (n = e.urlButton) || void 0 === n ? void 0 : n.url,
                                                    subtype: 'url'
                                                })
                                                : e.callButton
                                                    ? new a.TemplateButtonModel({
                                                        id: s,
                                                        displayText: e.callButton.displayText,
                                                        phoneNumber: e.callButton.phoneNumber,
                                                        subtype: 'call'
                                                    })
                                                    : new a.TemplateButtonModel({
                                                        id: s,
                                                        displayText: null === (i = e.quickReplyButton) || void 0 === i ? void 0 : i.displayText,
                                                        selectionId: null === (o = e.quickReplyButton) || void 0 === o ? void 0 : o.id,
                                                        subtype: 'quick_reply'
                                                    })
                                        })
                                    ))
                                : ((e.isDynamicReplyButtonsMsg = !0),
                                    (e.dynamicReplyButtons = t.buttons.map((e, t) => ({
                                        buttonId: e.id || `${t}`,
                                        buttonText: { displayText: e.text },
                                        type: 1
                                    }))),
                                    (e.replyButtons = new a.ButtonCollection()),
                                    e.replyButtons.add(
                                        e.dynamicReplyButtons.map((e) => {
                                            var t
                                            return new a.ReplyButtonModel({
                                                id: e.buttonId,
                                                displayText: (null === (t = e.buttonText) || void 0 === t ? void 0 : t.displayText) || void 0
                                            })
                                        })
                                    )),
                            e
                        )
                    }),
                        s.onInjected(() => {
                            ; (0, c.wrapModuleFunction)(l.createMsgProtobuf, (e, ...t) => {
                                var r
                                const [n] = t,
                                    i = e(...t)
                                if (n.hydratedButtons) {
                                    const e = { hydratedButtons: n.hydratedButtons }
                                    if (
                                        (n.footer && (e.hydratedFooterText = n.footer),
                                            n.caption && (e.hydratedContentText = n.caption),
                                            n.title && (e.hydratedTitleText = n.title),
                                            i.conversation)
                                    )
                                        (e.hydratedContentText = i.conversation), delete i.conversation
                                    else if (null === (r = i.extendedTextMessage) || void 0 === r ? void 0 : r.text)
                                        (e.hydratedContentText = i.extendedTextMessage.text), delete i.extendedTextMessage
                                    else {
                                        let t
                                        const r = ['documentMessage', 'imageMessage', 'locationMessage', 'videoMessage']
                                        for (const e of r)
                                            if (e in i) {
                                                t = e
                                                break
                                            }
                                        if (!t) return i
                                            ; (e[t] = i[t]),
                                                e.hydratedTitleText && !e.hydratedContentText && (e.hydratedContentText = e.hydratedTitleText),
                                                delete e.hydratedTitleText,
                                                'locationMessage' === t &&
                                                (e.hydratedContentText ||
                                                    (!i[t].name && !i[t].address) ||
                                                    (e.hydratedContentText =
                                                        i[t].name && i[t].address
                                                            ? `${i[t].name}\n${i[t].address}`
                                                            : i[t].name || i[t].address || '')),
                                                (e.hydratedContentText = e.hydratedContentText || ' '),
                                                delete i[t]
                                    }
                                    i.templateMessage = { hydratedTemplate: e }
                                }
                                return i
                            }),
                                setTimeout(() => {
                                    ; (0, c.wrapModuleFunction)(l.createMsgProtobuf, (e, ...t) => {
                                        const r = e(...t)
                                        return (
                                            r.templateMessage &&
                                            ((r.viewOnceMessage = { message: { templateMessage: r.templateMessage } }),
                                                delete r.templateMessage),
                                            r.buttonsMessage &&
                                            ((r.viewOnceMessage = { message: { buttonsMessage: r.buttonsMessage } }),
                                                delete r.buttonsMessage),
                                            r
                                        )
                                    })
                                }, 100),
                                (0, c.wrapModuleFunction)(l.encodeMaybeMediaType, (e, ...t) => {
                                    const [r] = t
                                    return 'button' === r ? u.DROP_ATTR : e(...t)
                                }),
                                (0, c.wrapModuleFunction)(l.mediaTypeFromProtobuf, (e, ...t) => {
                                    var r
                                    const [n] = t
                                    return (null === (r = n.templateMessage) || void 0 === r ? void 0 : r.hydratedTemplate)
                                        ? e(n.templateMessage.hydratedTemplate)
                                        : e(...t)
                                }),
                                (0, c.wrapModuleFunction)(l.typeAttributeFromProtobuf, (e, ...t) => {
                                    var r, n, i, o
                                    const [s] = t
                                    if (null === (r = s.templateMessage) || void 0 === r ? void 0 : r.hydratedTemplate) {
                                        const e = Object.keys(
                                            null === (n = s.templateMessage) || void 0 === n ? void 0 : n.hydratedTemplate
                                        )
                                        return ['documentMessage', 'imageMessage', 'locationMessage', 'videoMessage'].some((t) =>
                                            e.includes(t)
                                        )
                                            ? 'media'
                                            : 'text'
                                    }
                                    return 1 === (null === (i = s.buttonsMessage) || void 0 === i ? void 0 : i.headerType) ||
                                        2 === (null === (o = s.buttonsMessage) || void 0 === o ? void 0 : o.headerType)
                                        ? 'text'
                                        : e(...t)
                                })
                        })
            },
            6386: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.prepareRawMessage = void 0)
                const n = r(655),
                    i = r(3969),
                    o = r(9240),
                    s = r(2117),
                    a = r(3238),
                    u = r(6219),
                    c = r(4057),
                    l = r(313)
                t.prepareRawMessage = async function (e, t, r = {}) {
                    var d
                    if (
                        ((r = Object.assign(Object.assign({}, c.defaultSendMessageOptions), r)),
                            (t = Object.assign(
                                {
                                    t: (0, u.unixTime)(),
                                    from: s.UserPrefs.getMaybeMeUser(),
                                    to: e.id,
                                    self: 'out',
                                    isNewMsg: !0,
                                    local: !0,
                                    ack: a.ACK.CLOCK
                                },
                                t
                            )),
                            r.messageId)
                    ) {
                        if (
                            ('string' == typeof r.messageId && (r.messageId = s.MsgKey.fromString(r.messageId)),
                                !r.messageId.fromMe)
                        )
                            throw new o.WPPError('message_key_is_not_from_me', 'Message key is not from me', {
                                messageId: r.messageId.toString()
                            })
                        if (!r.messageId.remote.equals(e.id))
                            throw new o.WPPError(
                                'message_key_remote_id_is_not_same_of_chat',
                                'Message key remote ID is not same of chat',
                                { messageId: r.messageId.toString() }
                            )
                        t.id = r.messageId
                    }
                    if ((t.id || (t.id = (0, l.generateMessageID)(e)), r.mentionedList && !Array.isArray(r.mentionedList)))
                        throw new o.WPPError('mentioned_list_is_not_array', 'The option mentionedList is not an array', {
                            mentionedList: r.mentionedList
                        })
                    if (r.detectMentioned && e.isGroup && (!r.mentionedList || !r.mentionedList.length)) {
                        const n = 'chat' === t.type ? t.body : t.caption
                        r.mentionedList = r.mentionedList || []
                        const o = (null == n ? void 0 : n.match(/(?<=@)(\d+)\b/g)) || []
                        if (o.length > 0) {
                            const t = (await (0, i.getParticipants)(e.id)).map((e) => e.id.toString())
                            for (const e of o) {
                                const n = `${e}@c.us`
                                t.includes(n) && r.mentionedList.push(n)
                            }
                        }
                    }
                    if (r.mentionedList) {
                        const e = r.mentionedList.map((e) => (e instanceof s.Wid ? e : (0, n.assertWid)(e)))
                        for (const t of e)
                            if (!t.isUser())
                                throw new o.WPPError('mentioned_is_not_user', 'Mentioned is not an user', {
                                    mentionedId: t.toString()
                                })
                        t.mentionedJidList = e
                    }
                    if (r.quotedMsg) {
                        if (
                            ('string' == typeof r.quotedMsg && (r.quotedMsg = s.MsgKey.fromString(r.quotedMsg)),
                                r.quotedMsg instanceof s.MsgKey && (r.quotedMsg = await (0, l.getMessageById)(r.quotedMsg)),
                                !(r.quotedMsg instanceof s.MsgModel))
                        )
                            throw new o.WPPError('invalid_quoted_msg', 'Invalid quotedMsg', { quotedMsg: r.quotedMsg })
                        if (
                            !(null === (d = r.quotedMsg) || void 0 === d ? void 0 : d.isStatusV3) &&
                            !(0, u.canReplyMsg)(r.quotedMsg)
                        )
                            throw new o.WPPError('quoted_msg_can_not_reply', 'QuotedMsg can not reply', { quotedMsg: r.quotedMsg })
                        t = Object.assign(Object.assign({}, t), r.quotedMsg.msgContextInfo(e.id))
                    }
                    return t
                }
            },
            4482: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.requestPhoneNumber = void 0)
                const n = r(655),
                    i = r(9240),
                    o = r(4057),
                    s = r(313)
                t.requestPhoneNumber = async function (e, t = {}) {
                    t = Object.assign(Object.assign({}, o.defaultSendMessageOptions), t)
                    const r = (0, n.assertWid)(e)
                    if (!r.isLid())
                        throw new i.WPPError(
                            'not_a_lid_chat',
                            `requestPhoneNumber should not be called for non lid chat ${r.toString()}`
                        )
                    return await (0, s.sendRawMessage)(e, { type: 'request_phone_number' }, t)
                }
            },
            3216: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.sendCreatePollMessage = void 0)
                const n = r(4057),
                    i = r(313)
                t.sendCreatePollMessage = async function (e, t, r, o = {}) {
                    o = Object.assign(Object.assign({}, n.defaultSendMessageOptions), o)
                    const s = {
                        type: 'poll_creation',
                        pollName: t,
                        pollOptions: r.map((e, t) => ({ name: e, localId: t })),
                        pollEncKey: self.crypto.getRandomValues(new Uint8Array(32)),
                        pollSelectableOptionsCount: o.selectableCount || 0,
                        messageSecret: self.crypto.getRandomValues(new Uint8Array(32))
                    }
                    return await (0, i.sendRawMessage)(e, s, o)
                }
            },
            4625: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        },
                    s =
                        (this && this.__importDefault) ||
                        function (e) {
                            return e && e.__esModule ? e : { default: e }
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.sendFileMessage = void 0)
                const a = s(r(840)),
                    u = r(655),
                    c = r(9240),
                    l = r(5451),
                    d = o(r(1250)),
                    f = r(2117),
                    p = r(6700),
                    m = r(6219),
                    g = r(4057),
                    h = r(313),
                    y = (0, a.default)('WA-JS:message')
                    ; (t.sendFileMessage = async function (e, t, r) {
                        const n = (r = Object.assign(
                            Object.assign(Object.assign({}, g.defaultSendMessageOptions), { type: 'auto-detect' }),
                            r
                        )).createChat
                            ? await (0, u.assertFindChat)(e)
                            : (0, u.assertGetChat)(e),
                            i = await (0, l.convertToFile)(t, r.mimetype, r.filename),
                            o = i.name,
                            s = await f.OpaqueData.createFromData(i, i.type),
                            a = {}
                        let c
                        'audio' === r.type
                            ? (a.isPtt = r.isPtt)
                            : 'image' === r.type
                                ? (c = r.isViewOnce)
                                : 'video' === r.type
                                    ? (a.asGif = r.isGif)
                                    : 'document' === r.type
                                        ? (a.asDocument = !0)
                                        : 'sticker' === r.type && (a.asSticker = !0)
                        const d = f.MediaPrep.prepRawMedia(s, a)
                        let p = await (0, h.prepareRawMessage)(n, { caption: r.caption || o, filename: o, footer: r.footer }, r)
                            ; (p = (0, h.prepareMessageButtons)(p, r)),
                                r.markIsRead &&
                                (y('marking chat is read before send file'), await (0, h.markIsRead)(n.id).catch(() => null)),
                                await d.waitForPrep(),
                                y(`sending message (${r.type}) with id ${p.id}`)
                        const m = d.sendToChat(n, { caption: r.caption, footer: r.footer, isViewOnce: c, productMsgOptions: p }),
                            b = await new Promise((e) => {
                                n.msgs.on('add', function t(r) {
                                    r.id === p.id && (n.msgs.off('add', t), e(r))
                                })
                            })
                        function v(e, t) {
                            y(`message file ${b.id} is ${t}`)
                        }
                        if (
                            (y(`message file ${b.id} queued`),
                                b.on('change:mediaData.mediaStage', v),
                                m.finally(() => {
                                    b.off('change:mediaData.mediaStage', v)
                                }),
                                r.waitForAck)
                        ) {
                            y(`waiting ack for ${b.id}`)
                            const e = await m
                            y(`ack received for ${b.id} (ACK: ${b.ack}, SendResult: ${e})`)
                        }
                        return { id: b.id.toString(), ack: b.ack, sendMsgResult: m }
                    }),
                        d.onReady(() => {
                            ; (0, p.wrapModuleFunction)(m.generateVideoThumbsAndDuration, async (e, ...t) => {
                                const [r] = t
                                try {
                                    return await e(...t)
                                } catch (e) {
                                    if ('string' == typeof e.message && e.message.includes('MEDIA_ERR_SRC_NOT_SUPPORTED'))
                                        try {
                                            const e = await r.file.arrayBuffer(),
                                                t = (0, c.getVideoInfoFromBuffer)(e)
                                            return {
                                                duration: t.duration,
                                                thumbs: r.maxDimensions.map((e) =>
                                                    (function (e, t, r) {
                                                        let n = null != t ? t : r,
                                                            i = null != e ? e : r
                                                        n > i ? n > r && ((i *= r / n), (n = r)) : i > r && ((n *= r / i), (i = r))
                                                        const o = { width: Math.max(n, 1), height: Math.max(i, 1) },
                                                            s = document.createElement('canvas'),
                                                            a = s.getContext('2d')
                                                        return (
                                                            (s.width = o.width),
                                                            (s.height = o.height),
                                                            (a.fillStyle = 'white'),
                                                            a.fillRect(0, 0, s.width, s.height),
                                                            {
                                                                url: s.toDataURL('image/jpeg'),
                                                                width: o.width,
                                                                height: o.height,
                                                                fullWidth: e,
                                                                fullHeight: t
                                                            }
                                                        )
                                                    })(t.width, t.height, e)
                                                )
                                            }
                                        } catch (e) {
                                            console.error(e)
                                        }
                                    throw e
                                }
                            }),
                                (0, p.wrapModuleFunction)(m.processRawSticker, async (e, ...t) => {
                                    const [r] = t,
                                        n = await e(...t)
                                    if ('image/webp' === r.type()) {
                                        const e = r.forceToBlob(),
                                            t = await (0, c.blobToArrayBuffer)(e)
                                            ; (0, m.isAnimatedWebp)(t) && (n.mediaBlob = await f.OpaqueData.createFromData(e, r.type()))
                                    }
                                    return n
                                })
                        })
            },
            2393: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.sendListMessage = void 0)
                const s = r(9240),
                    a = o(r(1250)),
                    u = r(6700),
                    c = r(6219),
                    l = r(4057),
                    d = r(313)
                    ; (t.sendListMessage = async function (e, t) {
                        const r = (t = Object.assign(Object.assign({}, l.defaultSendMessageOptions), t)).sections
                        if (!Array.isArray(r)) throw new s.WPPError('invalid_list_type', 'Sections must be an array')
                        if (0 === r.length || r.length > 10)
                            throw new s.WPPError('invalid_list_size', 'Sections options must have between 1 and 10 options')
                        const n = {
                            type: 'list',
                            list: {
                                buttonText: t.buttonText,
                                description: t.description || ' ',
                                title: t.title,
                                footerText: t.footer,
                                listType: 1,
                                sections: r
                            },
                            footer: t.footer
                        }
                        return await (0, d.sendRawMessage)(e, n, t)
                    }),
                        a.onInjected(() => {
                            ; (0, u.wrapModuleFunction)(c.typeAttributeFromProtobuf, (e, ...t) => {
                                const [r] = t
                                return r.listMessage ? 'text' : e(...t)
                            }),
                                setTimeout(() => {
                                    ; (0, u.wrapModuleFunction)(c.createMsgProtobuf, (e, ...t) => {
                                        const r = e(...t)
                                        return (
                                            r.listMessage &&
                                            ((r.viewOnceMessage = { message: { listMessage: r.listMessage } }), delete r.listMessage),
                                            r
                                        )
                                    })
                                }, 100)
                        })
            },
            7635: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.sendLocationMessage = void 0)
                const s = o(r(1250)),
                    a = r(6700),
                    u = r(6219),
                    c = r(4057),
                    l = r(313),
                    d = r(9276)
                    ; (t.sendLocationMessage = async function (e, t) {
                        const r =
                            (t = Object.assign(Object.assign({}, c.defaultSendMessageOptions), t)).name && t.address
                                ? `${t.name}\n${t.address}`
                                : t.name || t.address || ''
                        'string' == typeof t.lat && (t.lat = parseFloat(t.lat)),
                            'string' == typeof t.lng && (t.lng = parseFloat(t.lng))
                        let n = { type: 'location', lat: t.lat, lng: t.lng, loc: r, clientUrl: t.url }
                        return (n = (0, d.prepareMessageButtons)(n, t)), await (0, l.sendRawMessage)(e, n, t)
                    }),
                        s.onInjected(() => {
                            ; (0, a.wrapModuleFunction)(u.typeAttributeFromProtobuf, (e, ...t) => {
                                const [r] = t
                                return r.locationMessage ? 'text' : e(...t)
                            })
                        })
            },
            4348: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__importDefault) ||
                    function (e) {
                        return e && e.__esModule ? e : { default: e }
                    }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.sendRawMessage = void 0)
                const i = n(r(840)),
                    o = r(655),
                    s = r(6219),
                    a = r(4057),
                    u = r(313),
                    c = (0, i.default)('WA-JS:message')
                t.sendRawMessage = async function (e, t, r = {}) {
                    const n = (r = Object.assign(Object.assign({}, a.defaultSendMessageOptions), r)).createChat
                        ? await (0, o.assertFindChat)(e)
                        : (0, o.assertGetChat)(e)
                        ; (t = await (0, u.prepareRawMessage)(n, t, r)),
                            r.markIsRead &&
                            (c('marking chat is read before send message'), await (0, u.markIsRead)(n.id).catch(() => null)),
                            c(`sending message (${t.type}) with id ${t.id}`)
                    const i = await (0, s.addAndSendMsgToChat)(n, t)
                    c(`message ${t.id} queued`)
                    const l = await i[0]
                    if (r.waitForAck) {
                        c(`waiting ack for ${t.id}`)
                        const e = await i[1]
                        c(`ack received for ${t.id} (ACK: ${l.ack}, SendResult: ${e})`)
                    }
                    return { id: l.id.toString(), ack: l.ack, sendMsgResult: i[1] }
                }
            },
            4347: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.sendReactionToMessage = void 0)
                const n = r(2117),
                    i = r(6219),
                    o = r(6914)
                t.sendReactionToMessage = async function (e, t) {
                    e instanceof n.MsgModel || 'string' == typeof e || 'function' != typeof e.toString || (e = e.toString())
                    const r = e instanceof n.MsgModel ? e : await (0, o.getMessageById)(e.toString())
                    return t || (t = ''), { sendMsgResult: await (0, i.sendReactionToMsg)(r, t) }
                }
            },
            3436: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.sendTextMessage = void 0)
                const n = r(4057),
                    i = r(313)
                t.sendTextMessage = async function (e, t, r = {}) {
                    r = Object.assign(Object.assign({}, n.defaultSendMessageOptions), r)
                    let o = { body: t, type: 'chat', subtype: null, urlText: null, urlNumber: null }
                    return (
                        (o = (0, i.prepareMessageButtons)(o, r)),
                        (o = await (0, i.prepareLinkPreview)(o, r)),
                        await (0, i.sendRawMessage)(e, o, r)
                    )
                }
            },
            7781: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.sendVCardContactMessage = void 0)
                const n = r(655),
                    i = r(2117),
                    o = r(4057),
                    s = r(313)
                t.sendVCardContactMessage = async function (e, t, r = {}) {
                    ; (r = Object.assign(Object.assign({}, o.defaultSendMessageOptions), r)), Array.isArray(t) || (t = [t])
                    const a = []
                    for (const e of t) {
                        let t = '',
                            r = ''
                        'object' == typeof e && 'name' in e ? ((t = e.id.toString()), (r = e.name)) : (t = e.toString())
                        let o = i.ContactStore.get(t)
                        o || (o = new i.ContactModel({ id: (0, n.assertWid)(t), name: r })),
                            !r && o.id.equals(i.UserPrefs.getMaybeMeUser()) && (r = o.displayName),
                            r &&
                            ((o = new i.ContactModel(o.attributes)),
                                (o.name = r),
                                Object.defineProperty(o, 'formattedName', { value: r }),
                                Object.defineProperty(o, 'displayName', { value: r })),
                            a.push(i.VCard.vcardFromContactModel(o))
                    }
                    const u = {}
                    return (
                        1 === a.length
                            ? ((u.type = 'vcard'), (u.body = a[0].vcard), (u.vcardFormattedName = a[0].displayName))
                            : ((u.type = 'multi_vcard'), (u.vcardList = a)),
                        (0, s.sendRawMessage)(e, u, r)
                    )
                }
            },
            5778: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.starMessage = void 0)
                const n = r(655),
                    i = r(2117),
                    o = r(313)
                t.starMessage = async function (e, t = !0) {
                    let r = !1
                    Array.isArray(e) || ((r = !0), (e = [e]))
                    const s = await (0, o.getMessageById)(e),
                        a = s.reduce((e, t) => {
                            const r = t.id.remote.toString()
                            return (e[r] = e[r] || []), e[r].push(t), e
                        }, {}),
                        u = s.map((e) => ({ id: e.id.toString(), star: e.star || !1 }))
                    for (const e in a) {
                        const r = (0, n.assertGetChat)(e),
                            o = a[e]
                        t ? i.Cmd.sendStarMsgs(r, o) : i.Cmd.sendUnstarMsgs(r, o),
                            r.promises.sendStarMsgs && (await r.promises.sendStarMsgs)
                    }
                    return r ? u[0] : u
                }
            },
            6588: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.unmute = void 0)
                const n = r(655)
                t.unmute = async function (e) {
                    const t = (0, n.assertWid)(e)
                    return (0, n.assertGetChat)(t).mute.unmute(!0)
                }
            },
            4057: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    r(7919),
                    r(4302),
                    i(r(3682), t),
                    i(r(313), t),
                    i(r(5468), t)
            },
            4302: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250)),
                    a = r(6700),
                    u = r(6219)
                function c() {
                    ; (0, a.wrapModuleFunction)(u.mediaTypeFromProtobuf, (e, ...t) => {
                        const [r] = t
                        if (r.deviceSentMessage) {
                            const { message: e } = r.deviceSentMessage
                            return e ? (0, u.mediaTypeFromProtobuf)(e) : null
                        }
                        if (r.ephemeralMessage) {
                            const { message: e } = r.ephemeralMessage
                            return e ? (0, u.mediaTypeFromProtobuf)(e) : null
                        }
                        if (r.viewOnceMessage) {
                            const { message: e } = r.viewOnceMessage
                            return e ? (0, u.mediaTypeFromProtobuf)(e) : null
                        }
                        return e(...t)
                    }),
                        (0, a.wrapModuleFunction)(u.typeAttributeFromProtobuf, (e, ...t) => {
                            const [r] = t
                            if (r.ephemeralMessage) {
                                const { message: e } = r.ephemeralMessage
                                return e ? (0, u.typeAttributeFromProtobuf)(e) : 'text'
                            }
                            if (r.deviceSentMessage) {
                                const { message: e } = r.deviceSentMessage
                                return e ? (0, u.typeAttributeFromProtobuf)(e) : 'text'
                            }
                            if (r.viewOnceMessage) {
                                const { message: e } = r.viewOnceMessage
                                return e ? (0, u.typeAttributeFromProtobuf)(e) : 'text'
                            }
                            return e(...t)
                        }),
                        (0, a.wrapModuleFunction)(u.isUnreadTypeMsg, (e, ...t) => {
                            const [r] = t
                            switch (r.type) {
                                case 'buttons_response':
                                case 'hsm':
                                case 'list':
                                case 'list_response':
                                case 'template_button_reply':
                                    return !0
                            }
                            return e(...t)
                        })
                }
                s.onInjected(() => {
                    setTimeout(c, 1e3)
                }),
                    s.onInjected(() => {
                        if ('stylex' in window) return
                        const e = s.search((e) => e.default.dedupe)
                            ; (null == e ? void 0 : e.default) && (window.stylex = null == e ? void 0 : e.default)
                    })
            },
            5468: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
            },
            4695: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.defaultConfig = void 0),
                    (t.defaultConfig = {
                        deviceName: !1,
                        liveLocationLimit: 10,
                        disableGoogleAnalytics: !1,
                        googleAnalyticsId: null,
                        googleAnalyticsUserProperty: {},
                        linkPreviewApiServers: null,
                        poweredBy: 'WA-JS'
                    })
            },
            5748: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.config = void 0)
                const n = r(8927),
                    i = r(4695),
                    o = window.WPPConfig || {},
                    s = Object.assign(Object.assign({}, i.defaultConfig), o),
                    a = (e = []) => ({
                        get: (t, r) =>
                            'isProxy' == r || ('object' == typeof t[r] && null != t[r] ? new Proxy(t[r], a([...e, r])) : t[r]),
                        set: (r, i, o) => {
                            r[i] = o
                            try {
                                n.internalEv.emitAsync('config.update', {
                                    config: t.config,
                                    key: i,
                                    path: [...e, i],
                                    target: r,
                                    value: o
                                })
                            } catch (e) { }
                            return !0
                        }
                    })
                    ; (t.config = new Proxy(s, a())), (window.WPPConfig = t.config)
            },
            8090: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    r(2821),
                    r(2247),
                    r(486),
                    r(3559),
                    r(6432),
                    r(6832),
                    r(8553),
                    r(4229),
                    r(5995)
            },
            2821: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117),
                    c = r(3073)
                a.onInjected(function () {
                    const e = async () => {
                        const e = await (0, c.getAuthCode)().catch(() => null)
                        s.internalEv.emit('conn.auth_code_change', e)
                    }
                    e(), u.Conn.on('change:ref', e)
                })
            },
            2247: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117),
                    c = r(3073)
                a.onInjected(function () {
                    let e = (0, c.isAuthenticated)()
                    const t = async () => {
                        e || (s.internalEv.emit('conn.authenticated'), (e = !1))
                    }
                    u.Cmd.isMainLoaded ? t() : u.Cmd.on('main_loaded', t),
                        u.Cmd.on('logout', () => {
                            e = !1
                        })
                })
            },
            486: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117)
                a.onInjected(function () {
                    u.Cmd.on('logout', () => s.internalEv.emit('conn.logout'))
                })
            },
            3559: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(4688)
                a.onInjected(function () {
                    const e = setInterval(() => {
                        ; (0, u.isMainInit)() && (clearInterval(e), s.internalEv.emit('conn.main_init'))
                    }, 100)
                })
            },
            6432: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117)
                a.onInjected(function () {
                    const e = async () => {
                        s.internalEv.emit('conn.main_loaded')
                    }
                    u.Cmd.isMainLoaded ? e() : u.Cmd.on('main_loaded', e)
                })
            },
            6832: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117)
                a.onInjected(function () {
                    const e = async () => {
                        s.internalEv.emit('conn.main_ready')
                    }
                    'MAIN' === u.Stream.mode ? e() : u.Cmd.on('main_stream_mode_ready_legacy', e)
                })
            },
            8553: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117)
                a.onInjected(function () {
                    const e = async () => {
                        s.internalEv.emit('conn.needs_update')
                    }
                    u.Stream.needsUpdate ? e() : u.Stream.on('change:needsUpdate', e)
                })
            },
            4229: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117),
                    c = r(3073)
                a.onInjected(function () {
                    const e = async () => {
                        ; (0, c.isIdle)() && s.internalEv.emit('conn.qrcode_idle')
                    }
                    e(), u.Socket.on('change:state', e)
                })
            },
            5995: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(2117),
                    c = r(2777),
                    l = r(3073)
                a.onInjected(function () {
                    let e = !1
                    const t = async () => {
                        ; (0, l.isAuthenticated)()
                            ? (e = !1)
                            : e ||
                            (u.Socket.state !== c.SOCKET_STATE.UNPAIRED && u.Socket.state !== c.SOCKET_STATE.UNPAIRED_IDLE) ||
                            ((e = !0), s.internalEv.emit('conn.require_auth'))
                    }
                    t(), u.Socket.on('change:state', t)
                })
            },
            2726: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getAuthCode = void 0)
                const n = r(2117),
                    i = r(4960),
                    o = r(4688)
                t.getAuthCode = async function () {
                    if (!n.Conn.ref || n.Conn.connected || (0, o.isAuthenticated)() || (0, o.isRegistered)()) return null
                    const e = n.Conn.ref
                    if ((0, o.isMultiDevice)()) {
                        const t = await i.waSignalStore.getRegistrationInfo(),
                            r = await i.waNoiseInfo.get(),
                            o = n.Base64.encodeB64(r.staticKeyPair.pubKey),
                            s = n.Base64.encodeB64(t.identityKeyPair.pubKey),
                            a = await Promise.resolve(i.adv.getADVSecretKey()),
                            u = [e, o, s, a].join(',')
                        return { type: 'multidevice', ref: e, staticKeyPair: o, identityKeyPair: s, secretKey: a, fullCode: u }
                    }
                    return null
                }
            },
            9072: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getHistorySyncProgress = void 0)
                const s = o(r(6219))
                t.getHistorySyncProgress = function () {
                    const e = s.getHistorySyncProgress()
                    return { progress: e.progress, paused: e.paused || !1, inProgress: e.inProgress || !1 }
                }
            },
            2697: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getMyDeviceId = void 0)
                const n = r(2117)
                t.getMyDeviceId = function () {
                    return n.UserPrefs.getMe()
                }
            },
            3112: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getMyUserId = void 0)
                const n = r(2117)
                t.getMyUserId = function () {
                    return n.UserPrefs.getMaybeMeUser()
                }
            },
            711: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getPlatform = void 0)
                const n = r(2117)
                t.getPlatform = function () {
                    return n.Conn.platform
                }
            },
            4688: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.setMultiDevice =
                        t.setKeepAlive =
                        t.refreshQR =
                        t.needsUpdate =
                        t.markUnavailable =
                        t.markAvailable =
                        t.logout =
                        t.isRegistered =
                        t.isMultiDevice =
                        t.isMainReady =
                        t.isMainLoaded =
                        t.isMainInit =
                        t.isIdle =
                        t.isAuthenticated =
                        t.getPlatform =
                        t.getMyUserId =
                        t.getMyDeviceId =
                        t.getHistorySyncProgress =
                        t.getAuthCode =
                        void 0)
                var n = r(2726)
                Object.defineProperty(t, 'getAuthCode', {
                    enumerable: !0,
                    get: function () {
                        return n.getAuthCode
                    }
                })
                var i = r(9072)
                Object.defineProperty(t, 'getHistorySyncProgress', {
                    enumerable: !0,
                    get: function () {
                        return i.getHistorySyncProgress
                    }
                })
                var o = r(2697)
                Object.defineProperty(t, 'getMyDeviceId', {
                    enumerable: !0,
                    get: function () {
                        return o.getMyDeviceId
                    }
                })
                var s = r(3112)
                Object.defineProperty(t, 'getMyUserId', {
                    enumerable: !0,
                    get: function () {
                        return s.getMyUserId
                    }
                })
                var a = r(711)
                Object.defineProperty(t, 'getPlatform', {
                    enumerable: !0,
                    get: function () {
                        return a.getPlatform
                    }
                })
                var u = r(6972)
                Object.defineProperty(t, 'isAuthenticated', {
                    enumerable: !0,
                    get: function () {
                        return u.isAuthenticated
                    }
                })
                var c = r(5029)
                Object.defineProperty(t, 'isIdle', {
                    enumerable: !0,
                    get: function () {
                        return c.isIdle
                    }
                })
                var l = r(9032)
                Object.defineProperty(t, 'isMainInit', {
                    enumerable: !0,
                    get: function () {
                        return l.isMainInit
                    }
                })
                var d = r(3956)
                Object.defineProperty(t, 'isMainLoaded', {
                    enumerable: !0,
                    get: function () {
                        return d.isMainLoaded
                    }
                })
                var f = r(7315)
                Object.defineProperty(t, 'isMainReady', {
                    enumerable: !0,
                    get: function () {
                        return f.isMainReady
                    }
                })
                var p = r(1537)
                Object.defineProperty(t, 'isMultiDevice', {
                    enumerable: !0,
                    get: function () {
                        return p.isMultiDevice
                    }
                })
                var m = r(2750)
                Object.defineProperty(t, 'isRegistered', {
                    enumerable: !0,
                    get: function () {
                        return m.isRegistered
                    }
                })
                var g = r(1819)
                Object.defineProperty(t, 'logout', {
                    enumerable: !0,
                    get: function () {
                        return g.logout
                    }
                })
                var h = r(3282)
                Object.defineProperty(t, 'markAvailable', {
                    enumerable: !0,
                    get: function () {
                        return h.markAvailable
                    }
                }),
                    Object.defineProperty(t, 'markUnavailable', {
                        enumerable: !0,
                        get: function () {
                            return h.markUnavailable
                        }
                    })
                var y = r(4239)
                Object.defineProperty(t, 'needsUpdate', {
                    enumerable: !0,
                    get: function () {
                        return y.needsUpdate
                    }
                })
                var b = r(7027)
                Object.defineProperty(t, 'refreshQR', {
                    enumerable: !0,
                    get: function () {
                        return b.refreshQR
                    }
                })
                var v = r(5821)
                Object.defineProperty(t, 'setKeepAlive', {
                    enumerable: !0,
                    get: function () {
                        return v.setKeepAlive
                    }
                })
                var _ = r(689)
                Object.defineProperty(t, 'setMultiDevice', {
                    enumerable: !0,
                    get: function () {
                        return _.setMultiDevice
                    }
                })
            },
            6972: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.isAuthenticated = void 0)
                const s = o(r(6219))
                t.isAuthenticated = function () {
                    return s.isAuthenticated()
                }
            },
            5029: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.isIdle = void 0)
                const n = r(2117),
                    i = r(2777)
                t.isIdle = function () {
                    return n.Socket.state === i.SOCKET_STATE.UNPAIRED_IDLE
                }
            },
            9032: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.isMainInit = void 0),
                    (t.isMainInit = function () {
                        var e
                        return Boolean(null === (e = window.Debug) || void 0 === e ? void 0 : e.VERSION)
                    })
            },
            3956: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.isMainLoaded = void 0)
                const n = r(2117)
                t.isMainLoaded = function () {
                    return n.Cmd.isMainLoaded
                }
            },
            7315: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.isMainReady = void 0)
                const n = r(8927)
                let i = !1
                n.internalEv.once('conn.main_ready', () => {
                    i = !0
                }),
                    (t.isMainReady = function () {
                        return i
                    })
            },
            1537: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.isMultiDevice = void 0)
                const s = o(r(1250))
                t.isMultiDevice = function () {
                    const e = s.search((e) => e.isMDBackend)
                    return !(null == e ? void 0 : e.isMDBackend) || e.isMDBackend()
                }
            },
            2750: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.isRegistered = void 0)
                const s = o(r(6219))
                t.isRegistered = function () {
                    return s.isRegistered()
                }
            },
            1819: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.logout = void 0)
                const n = r(2117)
                t.logout = async function () {
                    return (
                        n.Socket.logout(),
                        await new Promise((e) => {
                            n.Cmd.once('logout', e)
                        }),
                        !0
                    )
                }
            },
            3282: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.markUnavailable = t.markAvailable = void 0)
                const n = r(2117)
                async function i(e = !0) {
                    return (
                        Object.defineProperty(n.Stream, 'available', {
                            get: () => e,
                            set: (t) => {
                                t == e && n.Stream.trigger('change:available')
                            },
                            configurable: !0
                        }),
                        e ? n.Stream.markAvailable() : n.Stream.markUnavailable(),
                        !0
                    )
                }
                ; (t.markAvailable = i),
                    (t.markUnavailable = async function () {
                        return i(!1)
                    })
            },
            4239: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.needsUpdate = void 0)
                const n = r(2117)
                t.needsUpdate = function () {
                    return n.Stream.needsUpdate
                }
            },
            7027: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.refreshQR = void 0)
                const n = r(8927),
                    i = r(2117),
                    o = r(4688)
                t.refreshQR = async function () {
                    return (0, o.isAuthenticated)()
                        ? null
                        : ((0, o.isMultiDevice)() ? i.Cmd.refreshQR() : i.Socket.poke(),
                            await n.internalEv.waitFor('conn.auth_code_change').then((e) => e[0]))
                }
            },
            5821: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.setKeepAlive = void 0)
                const r = document.hasFocus
                let n
                t.setKeepAlive = function (e = !0) {
                    return (
                        e
                            ? ((document.hasFocus = () => !0),
                                (n = setInterval(() => document.dispatchEvent(new Event('scroll')), 15e3)))
                            : ((document.hasFocus = r), n && (clearInterval(n), (n = null))),
                        !!n
                    )
                }
            },
            689: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.setMultiDevice = void 0)
                const n = r(2117)
                t.setMultiDevice = function (e = !0) {
                    return e ? n.Cmd.upgradeToMDProd() : n.Cmd.downgradeWebclient(), !0
                }
            },
            3073: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), r(8090), i(r(4688), t), i(r(7694), t)
            },
            7694: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
            },
            7211: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getBusinessProfile = void 0)
                const n = r(655),
                    i = r(2117)
                t.getBusinessProfile = async function (e) {
                    const t = (0, n.assertWid)(e)
                    return await i.BusinessProfileStore.fetchBizProfile(t)
                }
            },
            1700: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getProfilePictureUrl = void 0)
                const n = r(655),
                    i = r(2117)
                t.getProfilePictureUrl = async function (e, t = !0) {
                    const r = (0, n.assertWid)(e),
                        o = await i.ProfilePicThumbStore.find(r)
                    if (o) return t ? o.imgFull : o.img
                }
            },
            6035: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getStatus = void 0)
                const n = r(655),
                    i = r(2117),
                    o = r(6453)
                t.getStatus = async function (e) {
                    const t = (0, n.assertWid)(e)
                    return ((await (0, o.queryExists)(t)) && (await i.StatusStore.find(t)).status) || null
                }
            },
            8216: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.queryExists = t.list = t.getStatus = t.getProfilePictureUrl = t.getBusinessProfile = void 0)
                var n = r(7211)
                Object.defineProperty(t, 'getBusinessProfile', {
                    enumerable: !0,
                    get: function () {
                        return n.getBusinessProfile
                    }
                })
                var i = r(1700)
                Object.defineProperty(t, 'getProfilePictureUrl', {
                    enumerable: !0,
                    get: function () {
                        return i.getProfilePictureUrl
                    }
                })
                var o = r(6035)
                Object.defineProperty(t, 'getStatus', {
                    enumerable: !0,
                    get: function () {
                        return o.getStatus
                    }
                })
                var s = r(774)
                Object.defineProperty(t, 'list', {
                    enumerable: !0,
                    get: function () {
                        return s.list
                    }
                })
                var a = r(6453)
                Object.defineProperty(t, 'queryExists', {
                    enumerable: !0,
                    get: function () {
                        return a.queryExists
                    }
                })
            },
            774: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.list = void 0)
                const n = r(2117)
                t.list = async function (e = {}) {
                    let t = n.ContactStore.getModelsArray().slice()
                    if ((e.onlyMyContacts && (t = t.filter((e) => e.isMyContact)), e.withLabels)) {
                        const r = e.withLabels.map((e) => {
                            const t = n.LabelStore.findFirst((t) => t.name === e)
                            return t ? t.id : e
                        })
                        t = t.filter((e) => {
                            var t
                            return null === (t = e.labels) || void 0 === t ? void 0 : t.some((e) => r.includes(e))
                        })
                    }
                    return t
                }
            },
            6453: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.queryExists = void 0)
                const n = r(655),
                    i = r(6219),
                    o = new Map()
                let s = null
                t.queryExists = async function (e) {
                    const t = (0, n.assertWid)(e),
                        r = t.toString()
                    if (o.has(r)) return o.get(r)
                    if (null === s) {
                        const e = i.sendQueryExists.toString()
                        s = !/`\+\$\{\w+\.toString\(\)\}`/.test(e)
                    }
                    let a = null
                    if (s) {
                        const t = (0, n.assertWid)(e),
                            r = t.toString
                        Object.defineProperty(t, 'toString', {
                            configurable: !0,
                            enumerable: !1,
                            value: () => `+${t._serialized}`
                        }),
                            (a = await (0, i.sendQueryExists)(t).catch(() => null)),
                            Object.defineProperty(t, 'toString', { configurable: !0, enumerable: !1, value: r })
                    }
                    return a || (a = await (0, i.sendQueryExists)(t).catch(() => null)), o.set(r, a), a
                }
            },
            3115: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), i(r(8216), t)
            },
            2626: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(5748),
                    a = o(r(1250))
                a.onInjected(() => {
                    if (!s.config.deviceName) return
                    const e = a.search((e) => e.default.info && e.default.hardRefresh)
                    if (e) {
                        const t = e.default.info()
                            ; (t.os = s.config.deviceName),
                                (t.version = void 0),
                                (t.name = void 0),
                                (t.ua = void 0),
                                (e.default.info = () => t)
                    }
                })
            },
            4382: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(3563)
                t.EventEmitter = n.EventEmitter2
            },
            5700: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
            },
            8927: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        },
                    o =
                        (this && this.__importDefault) ||
                        function (e) {
                            return e && e.__esModule ? e : { default: e }
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.waitFor =
                        t.stopListeningTo =
                        t.setMaxListeners =
                        t.removeListener =
                        t.removeAllListeners =
                        t.prependOnceListener =
                        t.prependMany =
                        t.prependListener =
                        t.prependAny =
                        t.once =
                        t.onAny =
                        t.on =
                        t.offAny =
                        t.off =
                        t.many =
                        t.listenersAny =
                        t.listeners =
                        t.listenerCount =
                        t.listenTo =
                        t.hasListeners =
                        t.getMaxListeners =
                        t.eventNames =
                        t.emitAsync =
                        t.emit =
                        t.addListener =
                        t.EventEmitter =
                        t.ev =
                        t.internalEv =
                        void 0)
                const s = o(r(840)),
                    a = r(4382)
                Object.defineProperty(t, 'EventEmitter', {
                    enumerable: !0,
                    get: function () {
                        return a.EventEmitter
                    }
                }),
                    i(r(5700), t)
                const u = (0, s.default)('WA-JS:event')
                    ; (t.internalEv = new a.EventEmitter({ maxListeners: 1 / 0 })),
                        (t.ev = new a.EventEmitter({ maxListeners: 1 / 0 })),
                        t.internalEv.onAny((e, ...r) => {
                            t.ev.emit(e, ...r), u.enabled && u(e, ...r)
                        }),
                        (t.addListener = t.ev.addListener.bind(t.ev)),
                        (t.emit = t.ev.emit.bind(t.ev)),
                        (t.emitAsync = t.ev.emitAsync.bind(t.ev)),
                        (t.eventNames = t.ev.eventNames.bind(t.ev)),
                        (t.getMaxListeners = t.ev.getMaxListeners.bind(t.ev)),
                        (t.hasListeners = t.ev.hasListeners.bind(t.ev)),
                        (t.listenTo = t.ev.listenTo.bind(t.ev)),
                        (t.listenerCount = t.ev.listenerCount.bind(t.ev)),
                        (t.listeners = t.ev.listeners.bind(t.ev)),
                        (t.listenersAny = t.ev.listenersAny.bind(t.ev)),
                        (t.many = t.ev.many.bind(t.ev)),
                        (t.off = t.ev.off.bind(t.ev)),
                        (t.offAny = t.ev.offAny.bind(t.ev)),
                        (t.on = t.ev.on.bind(t.ev)),
                        (t.onAny = t.ev.onAny.bind(t.ev)),
                        (t.once = t.ev.once.bind(t.ev)),
                        (t.prependAny = t.ev.prependAny.bind(t.ev)),
                        (t.prependListener = t.ev.prependListener.bind(t.ev)),
                        (t.prependMany = t.ev.prependMany.bind(t.ev)),
                        (t.prependOnceListener = t.ev.prependOnceListener.bind(t.ev)),
                        (t.removeAllListeners = t.ev.removeAllListeners.bind(t.ev)),
                        (t.removeListener = t.ev.removeListener.bind(t.ev)),
                        (t.setMaxListeners = t.ev.setMaxListeners.bind(t.ev)),
                        (t.stopListeningTo = t.ev.stopListeningTo.bind(t.ev)),
                        (t.waitFor = t.ev.waitFor.bind(t.ev))
            },
            2336: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), r(7593)
            },
            7593: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = r(8927),
                    a = o(r(1250)),
                    u = r(6700),
                    c = r(6219)
                a.onInjected(() =>
                    (function () {
                        const e = ['add', 'remove', 'demote', 'promote']
                            ; (0, u.wrapModuleFunction)(c.updateDBForGroupAction, (t, ...r) => {
                                const [n, i] = r
                                let o = i.actionType || i.action
                                return (
                                    e.includes(o) &&
                                    queueMicrotask(() => {
                                        var e
                                        const t = i.participants.map((e) => ('id' in e ? e.id : e))
                                        'add' === o && i.isInvite
                                            ? (o = 'join')
                                            : 'remove' === o && t.some((e) => e.equals(n.author)) && (o = 'leave'),
                                            s.internalEv.emit('group.participant_changed', {
                                                author: null === (e = n.author) || void 0 === e ? void 0 : e.toString(),
                                                authorPushName: n.pushname,
                                                groupId: n.chatId.toString(),
                                                action: o,
                                                operation: i.actionType || i.action,
                                                participants: t.map((e) => e.toString())
                                            })
                                    }),
                                    t(...r)
                                )
                            })
                    })()
                )
            },
            4447: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.addParticipants = void 0)
                const s = r(9240),
                    a = r(2117),
                    u = o(r(6219)),
                    c = r(6930),
                    l = {
                        403: "Can't join this group because the number was restricted it.",
                        409: "Can't join this group because the number is already a member of it."
                    }
                t.addParticipants = async function (e, t) {
                    const { groupChat: r, participants: n } = await (0, c.ensureGroupAndParticipants)(e, t, !0),
                        i = await u.sendAddParticipants(
                            r.id,
                            n.map((e) => e.id)
                        )
                    if (i.status >= 400)
                        throw new s.WPPError('group_add_participant_error', 'Failed to add participants to the group', {
                            groupId: e,
                            participantsIds: t
                        })
                    const o = {}
                    for (const e of i.participants || []) {
                        let t = null,
                            r = null,
                            n = null,
                            i = null
                        if ('userWid' in e) (t = e.userWid.toString()), (r = e.code), (n = e.invite_code), (i = e.invite_code_exp)
                        else {
                            t = Object.keys(e)[0]
                            const o = e[t]
                                ; (r = o.code), (n = o.invite_code), (i = o.invite_code_exp)
                        }
                        if ('403' !== r)
                            try {
                                a.ContactStore.gadd((0, s.createWid)(t), { silent: !0 })
                            } catch (e) { }
                        o[t] = {
                            wid: t,
                            code: Number(r),
                            message: l[Number(r)] || "Can't Join., unknown error",
                            invite_code: n,
                            invite_code_exp: Number(i) || null
                        }
                    }
                    return o
                }
            },
            7776: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.canAdd = void 0)
                const n = r(1804)
                t.canAdd = async function (e) {
                    return (await (0, n.ensureGroup)(e)).groupMetadata.participants.canAdd()
                }
            },
            7997: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.canDemote = void 0)
                const n = r(1804)
                t.canDemote = async function (e, t) {
                    const { groupChat: r, participants: i } = await (0, n.ensureGroupAndParticipants)(e, t)
                    return i.every((e) => r.groupMetadata.participants.canDemote(e))
                }
            },
            4548: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.canPromote = void 0)
                const n = r(1804)
                t.canPromote = async function (e, t) {
                    const { groupChat: r, participants: i } = await (0, n.ensureGroupAndParticipants)(e, t)
                    return i.every((e) => r.groupMetadata.participants.canPromote(e))
                }
            },
            8870: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.canRemove = void 0)
                const n = r(1804)
                t.canRemove = async function (e, t) {
                    const { groupChat: r, participants: i } = await (0, n.ensureGroupAndParticipants)(e, t)
                    return i.every((e) => r.groupMetadata.participants.canRemove(e))
                }
            },
            2889: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.create = void 0)
                const s = r(655),
                    a = o(r(4057)),
                    u = o(r(3115)),
                    c = r(9240),
                    l = r(2117),
                    d = o(r(6219))
                t.create = async function (e, t) {
                    var r
                    Array.isArray(t) || (t = [t])
                    const n = t.map(s.assertWid),
                        i = l.UserPrefs.getMaybeMeUser(),
                        o = []
                    for (const e of n) {
                        if (i.equals(e)) continue
                        const t = l.ContactStore.get(e)
                        if (t) {
                            o.push(t.id)
                            continue
                        }
                        const r = await u.queryExists(e)
                        if (!r) throw new c.WPPError('participant_not_exists', 'Participant not exists', { id: e })
                        i.equals(r.wid) || o.push(r.wid)
                    }
                    const f = await d.sendCreateGroup(e, o)
                    if (f.gid) {
                        const e = await a.find(f.gid)
                        !1 !== (null === (r = e.groupMetadata) || void 0 === r ? void 0 : r.stale) &&
                            (await new Promise((t) => {
                                e.on('change:groupMetadata.stale', function r() {
                                    var n
                                    !1 === (null === (n = e.groupMetadata) || void 0 === n ? void 0 : n.stale) &&
                                        (t(), e.off('change:groupMetadata.stale', r))
                                })
                            }))
                    }
                    const p = {}
                    for (const e of f.participants || []) {
                        let t = null,
                            r = null,
                            n = null,
                            i = null
                        if ('userWid' in e) (t = e.userWid.toString()), (r = e.code), (n = e.invite_code), (i = e.invite_code_exp)
                        else {
                            t = Object.keys(e)[0]
                            const o = e[t]
                                ; (r = o.code), (n = o.invite_code), (i = o.invite_code_exp)
                        }
                        p[t] = { wid: t, code: Number(r), invite_code: n, invite_code_exp: Number(i) || null }
                    }
                    return { gid: f.gid, participants: p }
                }
            },
            535: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.demoteParticipants = void 0)
                const s = r(9240),
                    a = o(r(6219)),
                    u = r(6930)
                t.demoteParticipants = async function (e, t) {
                    const { groupChat: r, participants: n } = await (0, u.ensureGroupAndParticipants)(e, t)
                    if (
                        n.some((e) => {
                            var t
                            return !(null === (t = r.groupMetadata) || void 0 === t ? void 0 : t.participants.canDemote(e))
                        })
                    )
                        throw new s.WPPError(
                            'group_participant_is_already_not_a_group_admin',
                            `Group ${r.id._serialized}: Group participant is already not a group admin`
                        )
                    return a.demoteParticipants(r, n)
                }
            },
            9848: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.ensureGroup = void 0)
                const n = r(655),
                    i = r(9240),
                    o = r(2117),
                    s = r(1804)
                t.ensureGroup = async function (e, t = !1) {
                    const r = (0, n.assertGetChat)(e)
                    if (!r.isGroup) throw new i.WPPError('not_a_group', `Chat ${r.id._serialized} is not a group`)
                    if ((await o.GroupMetadataStore.find(r.id), t && !(await (0, s.iAmAdmin)(e))))
                        throw new i.WPPError('group_you_are_not_admin', `You are not admin in ${r.id._serialized}`)
                    return r
                }
            },
            6930: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.ensureGroupAndParticipants = void 0)
                const n = r(655),
                    i = r(9240),
                    o = r(2117),
                    s = r(1804)
                t.ensureGroupAndParticipants = async function (e, t, r = !1) {
                    const a = await (0, s.ensureGroup)(e, !0)
                    Array.isArray(t) || (t = [t])
                    const u = t.map(n.assertWid).map((e) => {
                        var t
                        let n = null === (t = a.groupMetadata) || void 0 === t ? void 0 : t.participants.get(e)
                        if ((!n && r && (n = new o.ParticipantModel({ id: e })), !n))
                            throw new i.WPPError('group_participant_not_found', `Chat ${a.id._serialized} is not a group`)
                        return n
                    })
                    return { groupChat: a, participants: u }
                }
            },
            9635: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getAllGroups = void 0)
                const n = r(4057),
                    i = r(6219)
                t.getAllGroups = async function () {
                    const e = [],
                        t = await (0, i.queryAllGroups)()
                    for (const r of t) e.push((0, n.get)(r.id))
                    return e
                }
            },
            9752: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getGroupInfoFromInviteCode = void 0)
                const n = r(9240),
                    i = r(6219)
                t.getGroupInfoFromInviteCode = async function (e) {
                    var t, r, o
                    e = (e = (e = (e = e.replace('chat.whatsapp.com/', '')).replace('invite/', '')).replace(
                        'https://',
                        ''
                    )).replace('http://', '')
                    const s = await (0, i.sendQueryGroupInvite)(e).catch(() => null)
                    if (!s) throw new n.WPPError('invalid_invite_code', 'Invalid Invite Code', { inviteCode: e })
                    return Object.assign(Object.assign({}, s), {
                        descOwner: null === (t = s.descOwner) || void 0 === t ? void 0 : t.toString(),
                        id: s.id.toString(),
                        owner: null === (r = s.owner) || void 0 === r ? void 0 : r.toString(),
                        participants: s.participants.map((e) => Object.assign(Object.assign({}, e), { id: e.id.toString() })),
                        subjectOwner: null === (o = s.subjectOwner) || void 0 === o ? void 0 : o.toString()
                    })
                }
            },
            3858: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getGroupSizeLimit = void 0)
                const n = r(2117)
                t.getGroupSizeLimit = async function () {
                    return n.functions.getGroupSizeLimit()
                }
            },
            2114: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getInviteCode = void 0)
                const n = r(6219),
                    i = r(1804)
                t.getInviteCode = async function (e) {
                    const t = await (0, i.ensureGroup)(e, !0)
                    return await (0, n.sendQueryGroupInviteCode)(t.id)
                }
            },
            9950: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.getParticipants = void 0)
                const n = r(1804)
                t.getParticipants = async function (e) {
                    return (await (0, n.ensureGroup)(e)).groupMetadata.participants.getModelsArray()
                }
            },
            8557: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.iAmAdmin = void 0)
                const n = r(1804)
                t.iAmAdmin = async function (e) {
                    return (await (0, n.ensureGroup)(e)).groupMetadata.participants.iAmAdmin()
                }
            },
            2616: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.iAmMember = void 0)
                const n = r(1804)
                t.iAmMember = async function (e) {
                    return (await (0, n.ensureGroup)(e)).groupMetadata.participants.iAmMember()
                }
            },
            9714: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.iAmRestrictedMember = void 0)
                const n = r(1804)
                t.iAmRestrictedMember = async function (e) {
                    return (await (0, n.ensureGroup)(e)).groupMetadata.participants.iAmRestrictedMember()
                }
            },
            5742: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.iAmSuperAdmin = void 0)
                const n = r(1804)
                t.iAmSuperAdmin = async function (e) {
                    return (await (0, n.ensureGroup)(e)).groupMetadata.participants.iAmMember()
                }
            },
            1804: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.setSubject =
                        t.setProperty =
                        t.GroupProperty =
                        t.setIcon =
                        t.setDescription =
                        t.revokeInviteCode =
                        t.removeParticipants =
                        t.promoteParticipants =
                        t.leave =
                        t.join =
                        t.iAmSuperAdmin =
                        t.iAmRestrictedMember =
                        t.iAmMember =
                        t.iAmAdmin =
                        t.getParticipants =
                        t.getInviteCode =
                        t.getGroupSizeLimit =
                        t.getGroupInfoFromInviteCode =
                        t.getAllGroups =
                        t.ensureGroupAndParticipants =
                        t.ensureGroup =
                        t.demoteParticipants =
                        t.create =
                        t.canRemove =
                        t.canPromote =
                        t.canDemote =
                        t.canAdd =
                        t.addParticipants =
                        void 0)
                var n = r(4447)
                Object.defineProperty(t, 'addParticipants', {
                    enumerable: !0,
                    get: function () {
                        return n.addParticipants
                    }
                })
                var i = r(7776)
                Object.defineProperty(t, 'canAdd', {
                    enumerable: !0,
                    get: function () {
                        return i.canAdd
                    }
                })
                var o = r(7997)
                Object.defineProperty(t, 'canDemote', {
                    enumerable: !0,
                    get: function () {
                        return o.canDemote
                    }
                })
                var s = r(4548)
                Object.defineProperty(t, 'canPromote', {
                    enumerable: !0,
                    get: function () {
                        return s.canPromote
                    }
                })
                var a = r(8870)
                Object.defineProperty(t, 'canRemove', {
                    enumerable: !0,
                    get: function () {
                        return a.canRemove
                    }
                })
                var u = r(2889)
                Object.defineProperty(t, 'create', {
                    enumerable: !0,
                    get: function () {
                        return u.create
                    }
                })
                var c = r(535)
                Object.defineProperty(t, 'demoteParticipants', {
                    enumerable: !0,
                    get: function () {
                        return c.demoteParticipants
                    }
                })
                var l = r(9848)
                Object.defineProperty(t, 'ensureGroup', {
                    enumerable: !0,
                    get: function () {
                        return l.ensureGroup
                    }
                })
                var d = r(6930)
                Object.defineProperty(t, 'ensureGroupAndParticipants', {
                    enumerable: !0,
                    get: function () {
                        return d.ensureGroupAndParticipants
                    }
                })
                var f = r(9635)
                Object.defineProperty(t, 'getAllGroups', {
                    enumerable: !0,
                    get: function () {
                        return f.getAllGroups
                    }
                })
                var p = r(9752)
                Object.defineProperty(t, 'getGroupInfoFromInviteCode', {
                    enumerable: !0,
                    get: function () {
                        return p.getGroupInfoFromInviteCode
                    }
                })
                var m = r(3858)
                Object.defineProperty(t, 'getGroupSizeLimit', {
                    enumerable: !0,
                    get: function () {
                        return m.getGroupSizeLimit
                    }
                })
                var g = r(2114)
                Object.defineProperty(t, 'getInviteCode', {
                    enumerable: !0,
                    get: function () {
                        return g.getInviteCode
                    }
                })
                var h = r(9950)
                Object.defineProperty(t, 'getParticipants', {
                    enumerable: !0,
                    get: function () {
                        return h.getParticipants
                    }
                })
                var y = r(8557)
                Object.defineProperty(t, 'iAmAdmin', {
                    enumerable: !0,
                    get: function () {
                        return y.iAmAdmin
                    }
                })
                var b = r(2616)
                Object.defineProperty(t, 'iAmMember', {
                    enumerable: !0,
                    get: function () {
                        return b.iAmMember
                    }
                })
                var v = r(9714)
                Object.defineProperty(t, 'iAmRestrictedMember', {
                    enumerable: !0,
                    get: function () {
                        return v.iAmRestrictedMember
                    }
                })
                var _ = r(5742)
                Object.defineProperty(t, 'iAmSuperAdmin', {
                    enumerable: !0,
                    get: function () {
                        return _.iAmSuperAdmin
                    }
                })
                var M = r(757)
                Object.defineProperty(t, 'join', {
                    enumerable: !0,
                    get: function () {
                        return M.join
                    }
                })
                var P = r(3164)
                Object.defineProperty(t, 'leave', {
                    enumerable: !0,
                    get: function () {
                        return P.leave
                    }
                })
                var w = r(5267)
                Object.defineProperty(t, 'promoteParticipants', {
                    enumerable: !0,
                    get: function () {
                        return w.promoteParticipants
                    }
                })
                var O = r(4249)
                Object.defineProperty(t, 'removeParticipants', {
                    enumerable: !0,
                    get: function () {
                        return O.removeParticipants
                    }
                })
                var j = r(4051)
                Object.defineProperty(t, 'revokeInviteCode', {
                    enumerable: !0,
                    get: function () {
                        return j.revokeInviteCode
                    }
                })
                var x = r(4469)
                Object.defineProperty(t, 'setDescription', {
                    enumerable: !0,
                    get: function () {
                        return x.setDescription
                    }
                })
                var C = r(3034)
                Object.defineProperty(t, 'setIcon', {
                    enumerable: !0,
                    get: function () {
                        return C.setIcon
                    }
                })
                var S = r(7496)
                Object.defineProperty(t, 'GroupProperty', {
                    enumerable: !0,
                    get: function () {
                        return S.GroupProperty
                    }
                }),
                    Object.defineProperty(t, 'setProperty', {
                        enumerable: !0,
                        get: function () {
                            return S.setProperty
                        }
                    })
                var I = r(1760)
                Object.defineProperty(t, 'setSubject', {
                    enumerable: !0,
                    get: function () {
                        return I.setSubject
                    }
                })
            },
            757: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.join = void 0)
                const n = r(6219)
                t.join = async function (e) {
                    return (
                        (e = (e = (e = (e = e.replace('chat.whatsapp.com/', '')).replace('invite/', '')).replace(
                            'https://',
                            ''
                        )).replace('http://', '')),
                        { id: (await (0, n.sendJoinGroupViaInvite)(e)).toString() }
                    )
                }
            },
            3164: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.leave = void 0)
                const n = r(6219),
                    i = r(1804)
                t.leave = async function (e) {
                    const t = await (0, i.ensureGroup)(e)
                    return await (0, n.sendExitGroup)(t)
                }
            },
            5267: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.promoteParticipants = void 0)
                const s = r(9240),
                    a = o(r(6219)),
                    u = r(6930)
                t.promoteParticipants = async function (e, t) {
                    const { groupChat: r, participants: n } = await (0, u.ensureGroupAndParticipants)(e, t)
                    if (
                        n.some((e) => {
                            var t
                            return !(null === (t = r.groupMetadata) || void 0 === t ? void 0 : t.participants.canPromote(e))
                        })
                    )
                        throw new s.WPPError(
                            'group_participant_is_already_a_group_admin',
                            `Group ${r.id._serialized}: Group participant is already a group admin`
                        )
                    return a.promoteParticipants(r, n)
                }
            },
            4249: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.removeParticipants = void 0)
                const s = r(9240),
                    a = o(r(6219)),
                    u = r(6930)
                t.removeParticipants = async function (e, t) {
                    const { groupChat: r, participants: n } = await (0, u.ensureGroupAndParticipants)(e, t)
                    if (
                        n.some((e) => {
                            var t
                            return !(null === (t = r.groupMetadata) || void 0 === t ? void 0 : t.participants.canRemove(e))
                        })
                    )
                        throw new s.WPPError(
                            'group_participant_is_not_a_group_member',
                            `Group ${r.id._serialized}: Group participant is not a group member`
                        )
                    return a.removeParticipants(r, n)
                }
            },
            4051: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.revokeInviteCode = void 0)
                const n = r(6219),
                    i = r(1804)
                t.revokeInviteCode = async function (e) {
                    const t = await (0, i.ensureGroup)(e, !0)
                    return await (0, n.sendRevokeGroupInviteCode)(t.id)
                }
            },
            4469: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.setDescription = void 0)
                const n = r(9240),
                    i = r(6219),
                    o = r(1804)
                t.setDescription = async function (e, t) {
                    var r, s
                    const a = await (0, o.ensureGroup)(e)
                    if (!(null === (r = a.groupMetadata) || void 0 === r ? void 0 : r.canSetDescription()))
                        throw new n.WPPError(
                            'you_are_not_allowed_set_group_description',
                            `You are not allowed to set group description in ${a.id._serialized}`,
                            { groupId: a.id.toString() }
                        )
                    const u = (0, i.randomMessageId)()
                    return (
                        await (0, i.sendSetGroupDescription)(
                            a.id,
                            t,
                            u,
                            null === (s = a.groupMetadata) || void 0 === s ? void 0 : s.descId
                        ),
                        (a.groupMetadata.descId = u),
                        (a.groupMetadata.desc = t),
                        !0
                    )
                }
            },
            3034: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.setIcon = void 0)
                const n = r(9240),
                    i = r(6219),
                    o = r(1804)
                t.setIcon = async function (e, t) {
                    const r = await (0, o.ensureGroup)(e)
                    if (await (0, o.iAmRestrictedMember)(e))
                        throw new n.WPPError(
                            'group_you_are_restricted_member',
                            `You are a restricted member in ${r.id._serialized}`
                        )
                    const s = await (0, n.convertToFile)(t),
                        a = await (0, n.resizeImage)(s, { width: 96, height: 96, mimeType: 'image/jpeg', resize: 'cover' }),
                        u = await (0, n.resizeImage)(s, { width: 640, height: 640, mimeType: 'image/jpeg', resize: 'cover' }),
                        c = await (0, n.blobToBase64)(a),
                        l = await (0, n.blobToBase64)(u)
                    return (0, i.sendSetPicture)(r.id, c, l)
                }
            },
            7496: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.setProperty = t.GroupProperty = void 0)
                const n = r(9240),
                    i = r(6219),
                    o = r(1804)
                var s
                !(function (e) {
                    ; (e.ANNOUNCEMENT = 'announcement'), (e.EPHEMERAL = 'ephemeral'), (e.RESTRICT = 'restrict')
                })((s = t.GroupProperty || (t.GroupProperty = {}))),
                    (t.setProperty = async function (e, t, r) {
                        var a, u
                        const c = await (0, o.ensureGroup)(e)
                        if (
                            t !== s.ANNOUNCEMENT &&
                            !(null === (a = c.groupMetadata) || void 0 === a ? void 0 : a.canSetGroupProperty())
                        )
                            throw new n.WPPError(
                                'you_are_not_allowed_set_group_property',
                                `You are not allowed to set property in ${c.id._serialized}`,
                                { groupId: c.id.toString() }
                            )
                        if (
                            t == s.ANNOUNCEMENT &&
                            !(null === (u = c.groupMetadata) || void 0 === u ? void 0 : u.canSetEphemeralSetting())
                        )
                            throw new n.WPPError(
                                'you_are_not_allowed_set_ephemeral_setting',
                                `You are not allowed to set ephemeral setting in ${c.id._serialized}`,
                                { groupId: c.id.toString() }
                            )
                        if (t === s.EPHEMERAL) {
                            if ((('boolean' != typeof r && 1 !== r) || (r = 604800), [0, 86400, 604800, 7776e3].includes(r)))
                                throw new n.WPPError('invalid_ephemeral_duration', 'Invalid ephemeral duration', { value: r })
                        } else r = r ? 1 : 0
                        return await (0, i.sendSetGroupProperty)(c.id, t, r), !0
                    })
            },
            1760: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.setSubject = void 0)
                const n = r(9240),
                    i = r(6219),
                    o = r(1804)
                t.setSubject = async function (e, t) {
                    var r
                    const s = await (0, o.ensureGroup)(e)
                    if (!(null === (r = s.groupMetadata) || void 0 === r ? void 0 : r.canSetSubject()))
                        throw new n.WPPError(
                            'you_are_not_allowed_set_group_subject',
                            `You are not allowed to set group subject in ${s.id._serialized}`,
                            { groupId: s.id.toString() }
                        )
                    return await (0, i.sendSetGroupSubject)(s.id, t), (s.name = t), (s.formattedTitle = t), !0
                }
            },
            3969: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), r(2336), i(r(1804), t)
            },
            3764: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__decorate) ||
                    function (e, t, r, n) {
                        var i,
                            o = arguments.length,
                            s = o < 3 ? t : null === n ? (n = Object.getOwnPropertyDescriptor(t, r)) : n
                        if ('object' == typeof Reflect && 'function' == typeof Reflect.decorate) s = Reflect.decorate(e, t, r, n)
                        else
                            for (var a = e.length - 1; a >= 0; a--)
                                (i = e[a]) && (s = (o < 3 ? i(s) : o > 3 ? i(t, r, s) : i(t, r)) || s)
                        return o > 3 && s && Object.defineProperty(t, r, s), s
                    }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.Tracker = void 0)
                const i = r(1407)
                function o(e = 0, t = 2147483647) {
                    return Math.floor(Math.random() * (t - e + 1) + e)
                }
                class s {
                    static get clientState() {
                        const e = !localStorage.cid,
                            t = localStorage.cid || sessionStorage.cid || o(1e9) + '.' + Math.floor(Date.now() / 1e3)
                        return (localStorage.cid = sessionStorage.cid = t), { firstVisit: e, cid: t }
                    }
                    constructor(e) {
                        ; (this.trackingId = e),
                            (this.events = []),
                            (this.userProperties = {}),
                            (this.lastTime = Date.now()),
                            (this.hitsCount = 1),
                            (this.documentTitle = '')
                    }
                    get sid() {
                        const e = `${this.trackingId}_sid`,
                            t = sessionStorage[e] || Math.floor(Date.now() / 1e3)
                        return (sessionStorage[e] = t), t
                    }
                    get sct() {
                        const e = `${this.trackingId}_sct`
                        let t = parseInt(localStorage[e])
                        return isNaN(t) && (t = 0), (localStorage[e] = t + 1), localStorage[e]
                    }
                    getHeader() {
                        const { cid: e, firstVisit: t } = s.clientState
                        return {
                            v: 2,
                            tid: this.trackingId,
                            _p: s.pageLoadHash,
                            cid: e,
                            _fv: t ? 1 : void 0,
                            ul: (navigator.language || '').toLowerCase() || void 0,
                            sr: `${screen.width}x${screen.height}`,
                            _s: this.hitsCount++,
                            sid: this.sid,
                            sct: this.sct,
                            seg: 1,
                            dl: location.href,
                            dr: document.referrer,
                            dt: this.documentTitle || document.title
                        }
                    }
                    getUserProperties() {
                        const e = this.userProperties
                        return (
                            (this.userProperties = {}),
                            Object.entries(e)
                                .filter(([, e]) => void 0 !== e)
                                .map(([e, t]) => ('number' == typeof t ? [`upn.${e}`, String(t)] : [`up.${e}`, String(t)]))
                        )
                    }
                    processEvents() {
                        const e = this.events
                        if (((this.events = []), !e.length)) return
                        const t = e.map(([e, t, r]) => {
                            const n = []
                            if ((n.push(['en', e]), n.push(['_ee', '1']), t))
                                for (const e in t) {
                                    const r = t[e]
                                    void 0 !== r &&
                                        ('number' == typeof r ? n.push([`epn.${e}`, String(r)]) : n.push([`ep.${e}`, String(r)]))
                                }
                            return n.push(['_et', String(r)]), n
                        }),
                            r = Object.entries(this.getHeader())
                                .filter(([, e]) => void 0 !== e)
                                .map(([e, t]) => [e, String(t)])
                        r.push(...this.getUserProperties())
                        const n = new URLSearchParams(r)
                        if (1 === t.length) {
                            for (const [e, r] of t[0]) n.append(e, r)
                            navigator.sendBeacon(`${s.collectURL}?${n.toString()}`)
                        } else {
                            const e = t.map((e) => new URLSearchParams(e).toString())
                            navigator.sendBeacon(`${s.collectURL}?${n.toString()}`, e.join('\n'))
                        }
                    }
                    processUserEngagement() {
                        this.trackEvent('user_engagement')
                    }
                    trackEvent(e, t) {
                        const r = Date.now(),
                            n = r - this.lastTime
                            ; (this.lastTime = r), this.events.push([e, t, n]), this.processEvents(), this.processUserEngagement()
                    }
                    setUserProperty(e, t) {
                        ; (this.userProperties[e] = t), this.trackEvent('user_engagement')
                    }
                }
                ; (s.collectURL = 'https://www.google-analytics.com/g/collect'),
                    (s.pageLoadHash = o()),
                    n([(0, i.debounce)(1e3)], s.prototype, 'processEvents', null),
                    n([(0, i.debounce)(3e5)], s.prototype, 'processUserEngagement', null),
                    (t.Tracker = s)
            },
            5367: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        },
                    s =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.trackException = t.waVersion = void 0)
                const a = r(5748),
                    u = o(r(3073)),
                    c = r(8927),
                    l = r(3764)
                s(r(3764), t), (t.waVersion = '2.18.4')
                const d = ['W: ', '-', ', WA-JS: ', t.waVersion],
                    f = new l.Tracker('G-MTQ4KY110F'),
                    p = a.config.googleAnalyticsId ? new l.Tracker(a.config.googleAnalyticsId) : null
                c.internalEv.on('webpack.injected', () => {
                    f.documentTitle = d.join('')
                    const e = u.isAuthenticated(),
                        r = u.isMultiDevice() ? 'multidevice' : 'legacy'
                    if (
                        (f.setUserProperty('method', r),
                            f.setUserProperty('wa_js', t.waVersion),
                            f.setUserProperty('powered_by', a.config.poweredBy || '-'),
                            c.internalEv.on('conn.main_init', () => {
                                var e
                                    ; (d[1] = (null === (e = window.Debug) || void 0 === e ? void 0 : e.VERSION) || '-'),
                                        (f.documentTitle = d.join('')),
                                        f.setUserProperty('whatsapp', d[1])
                            }),
                            f.trackEvent('page_view', { authenticated: e, method: r }),
                            p)
                    ) {
                        if (
                            ((p.documentTitle = d.join('-')),
                                p.setUserProperty('method', r),
                                p.setUserProperty('wa_js', t.waVersion),
                                p.setUserProperty('powered_by', a.config.poweredBy || '-'),
                                c.internalEv.on('conn.main_init', () => {
                                    var e
                                        ; (d[1] = (null === (e = window.Debug) || void 0 === e ? void 0 : e.VERSION) || '-'),
                                            (p.documentTitle = d.join('')),
                                            p.setUserProperty('whatsapp', d[1])
                                }),
                                'object' == typeof a.config.googleAnalyticsUserProperty)
                        )
                            for (const e in a.config.googleAnalyticsUserProperty) {
                                const t = a.config.googleAnalyticsUserProperty[e]
                                p.setUserProperty(e, t)
                            }
                        p.trackEvent('page_view', { authenticated: e, method: r })
                    }
                    c.internalEv.on('config.update', (e) => {
                        if ('poweredBy' === e.path[0])
                            f.setUserProperty('powered_by', e.value || '-'), p && p.setUserProperty('powered_by', e.value || '-')
                        else if (
                            'googleAnalyticsUserProperty' === e.path[0] &&
                            p &&
                            'object' == typeof a.config.googleAnalyticsUserProperty
                        )
                            for (const e in a.config.googleAnalyticsUserProperty) {
                                const t = a.config.googleAnalyticsUserProperty[e]
                                p.setUserProperty(e, t)
                            }
                    })
                }),
                    a.config.disableGoogleAnalytics ||
                    (c.internalEv.on('conn.authenticated', () => {
                        const e = u.isMultiDevice() ? 'multidevice' : 'legacy'
                        f.trackEvent('login', { method: e }), p && f.trackEvent('login', { method: e })
                    }),
                        c.internalEv.on('conn.logout', () => {
                            const e = u.isMultiDevice() ? 'multidevice' : 'legacy'
                            f.trackEvent('logout', { method: e }), p && p.trackEvent('logout', { method: e })
                        })),
                    (t.trackException = function (e, t = !1) {
                        a.config.disableGoogleAnalytics ||
                            (f.trackEvent('exception', { description: e, fatal: t }),
                                p && p.trackEvent('exception', { description: e, fatal: t }))
                    })
            },
            4882: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.license =
                        t.supportedWhatsappWeb =
                        t.version =
                        t.waitFor =
                        t.stopListeningTo =
                        t.setMaxListeners =
                        t.removeListener =
                        t.removeAllListeners =
                        t.prependOnceListener =
                        t.prependMany =
                        t.prependListener =
                        t.prependAny =
                        t.once =
                        t.onAny =
                        t.on =
                        t.offAny =
                        t.off =
                        t.many =
                        t.listenersAny =
                        t.listeners =
                        t.listenerCount =
                        t.listenTo =
                        t.hasListeners =
                        t.getMaxListeners =
                        t.eventNames =
                        t.emitAsync =
                        t.emit =
                        t.whatsapp =
                        t.group =
                        t.chat =
                        t.config =
                        t.isReady =
                        t.isInjected =
                        t.webpack =
                        void 0),
                    r(5748),
                    r(2626),
                    r(5367)
                const s = o(r(1250))
                t.webpack = s
                var a = r(1250)
                Object.defineProperty(t, 'isInjected', {
                    enumerable: !0,
                    get: function () {
                        return a.isInjected
                    }
                }),
                    Object.defineProperty(t, 'isReady', {
                        enumerable: !0,
                        get: function () {
                            return a.isReady
                        }
                    })
                var u = r(5748)
                Object.defineProperty(t, 'config', {
                    enumerable: !0,
                    get: function () {
                        return u.config
                    }
                }),
                    (t.chat = o(r(4057))),
                    (t.group = o(r(3969))),
                    (t.whatsapp = o(r(2117)))
                var c = r(8927)
                Object.defineProperty(t, 'emit', {
                    enumerable: !0,
                    get: function () {
                        return c.emit
                    }
                }),
                    Object.defineProperty(t, 'emitAsync', {
                        enumerable: !0,
                        get: function () {
                            return c.emitAsync
                        }
                    }),
                    Object.defineProperty(t, 'eventNames', {
                        enumerable: !0,
                        get: function () {
                            return c.eventNames
                        }
                    }),
                    Object.defineProperty(t, 'getMaxListeners', {
                        enumerable: !0,
                        get: function () {
                            return c.getMaxListeners
                        }
                    }),
                    Object.defineProperty(t, 'hasListeners', {
                        enumerable: !0,
                        get: function () {
                            return c.hasListeners
                        }
                    }),
                    Object.defineProperty(t, 'listenTo', {
                        enumerable: !0,
                        get: function () {
                            return c.listenTo
                        }
                    }),
                    Object.defineProperty(t, 'listenerCount', {
                        enumerable: !0,
                        get: function () {
                            return c.listenerCount
                        }
                    }),
                    Object.defineProperty(t, 'listeners', {
                        enumerable: !0,
                        get: function () {
                            return c.listeners
                        }
                    }),
                    Object.defineProperty(t, 'listenersAny', {
                        enumerable: !0,
                        get: function () {
                            return c.listenersAny
                        }
                    }),
                    Object.defineProperty(t, 'many', {
                        enumerable: !0,
                        get: function () {
                            return c.many
                        }
                    }),
                    Object.defineProperty(t, 'off', {
                        enumerable: !0,
                        get: function () {
                            return c.off
                        }
                    }),
                    Object.defineProperty(t, 'offAny', {
                        enumerable: !0,
                        get: function () {
                            return c.offAny
                        }
                    }),
                    Object.defineProperty(t, 'on', {
                        enumerable: !0,
                        get: function () {
                            return c.on
                        }
                    }),
                    Object.defineProperty(t, 'onAny', {
                        enumerable: !0,
                        get: function () {
                            return c.onAny
                        }
                    }),
                    Object.defineProperty(t, 'once', {
                        enumerable: !0,
                        get: function () {
                            return c.once
                        }
                    }),
                    Object.defineProperty(t, 'prependAny', {
                        enumerable: !0,
                        get: function () {
                            return c.prependAny
                        }
                    }),
                    Object.defineProperty(t, 'prependListener', {
                        enumerable: !0,
                        get: function () {
                            return c.prependListener
                        }
                    }),
                    Object.defineProperty(t, 'prependMany', {
                        enumerable: !0,
                        get: function () {
                            return c.prependMany
                        }
                    }),
                    Object.defineProperty(t, 'prependOnceListener', {
                        enumerable: !0,
                        get: function () {
                            return c.prependOnceListener
                        }
                    }),
                    Object.defineProperty(t, 'removeAllListeners', {
                        enumerable: !0,
                        get: function () {
                            return c.removeAllListeners
                        }
                    }),
                    Object.defineProperty(t, 'removeListener', {
                        enumerable: !0,
                        get: function () {
                            return c.removeListener
                        }
                    }),
                    Object.defineProperty(t, 'setMaxListeners', {
                        enumerable: !0,
                        get: function () {
                            return c.setMaxListeners
                        }
                    }),
                    Object.defineProperty(t, 'stopListeningTo', {
                        enumerable: !0,
                        get: function () {
                            return c.stopListeningTo
                        }
                    }),
                    Object.defineProperty(t, 'waitFor', {
                        enumerable: !0,
                        get: function () {
                            return c.waitFor
                        }
                    }),
                    (t.version = '2.18.4'),
                    (t.supportedWhatsappWeb = '>=2.2245.8-beta'),
                    (t.license = 'Apache-2.0'),
                    s.injectLoader()
            },
            6973: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.blobToArrayBuffer = void 0),
                    (t.blobToArrayBuffer = function (e) {
                        return new Promise((t, r) => {
                            const n = new FileReader()
                                ; (n.onloadend = function () {
                                    t(n.result)
                                }),
                                    (n.onabort = r),
                                    (n.onerror = r),
                                    n.readAsArrayBuffer(e)
                        })
                    })
            },
            881: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.blobToBase64 = void 0),
                    (t.blobToBase64 = function (e) {
                        return new Promise((t, r) => {
                            const n = new FileReader()
                                ; (n.onloadend = function () {
                                    t(n.result)
                                }),
                                    (n.onabort = r),
                                    (n.onerror = r),
                                    n.readAsDataURL(e)
                        })
                    })
            },
            5451: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__importDefault) ||
                    function (e) {
                        return e && e.__esModule ? e : { default: e }
                    }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.convertToFile = void 0)
                const i = n(r(5834)),
                    o = n(r(5705)),
                    s = r(9240)
                t.convertToFile = async function (e, t, r) {
                    let n = (0, o.default)(e)
                    if ((!n && (0, s.isBase64)(e) && (n = (0, o.default)('data:;base64,' + e)), !n)) throw 'invalid_data_url'
                    t || (t = n.contentType)
                    const a = n.toBuffer(),
                        u = new Blob([new Uint8Array(a, a.byteOffset, a.length)], { type: t })
                    if (!r || !t) {
                        const e = await i.default.fromBuffer(a)
                        if (e) {
                            const n = e.mime.split('/')[0]
                                ; (r = r || `${n}.${e.ext}`), (t = t || e.mime)
                        }
                        ; (r = r || 'unknown'), (t = t || 'application/octet-stream')
                    }
                    return new File([u], r, { type: t, lastModified: Date.now() })
                }
            },
            616: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.createWid = void 0)
                const n = r(2117)
                t.createWid = function (e) {
                    if (e) {
                        if (n.WidFactory.isWidlike(e)) return n.WidFactory.createWidFromWidLike(e)
                        if (
                            (e && 'object' == typeof e && 'object' == typeof e._serialized && (e = e._serialized),
                                'string' == typeof e)
                        )
                            return /^\d+$/.test(e)
                                ? n.WidFactory.createUserWid(e, 'c.us')
                                : /^\d+-\d+$/.test(e)
                                    ? n.WidFactory.createUserWid(e, 'g.us')
                                    : /status$/.test(e)
                                        ? n.WidFactory.createUserWid(e, 'broadcast')
                                        : n.WidFactory.createWid(e)
                    }
                }
            },
            2101: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.downloadImage = void 0),
                    (t.downloadImage = function (e, t = 'image/jpeg', r = 0.85) {
                        return new Promise((n, i) => {
                            const o = new Image()
                                ; (o.crossOrigin = 'anonymous'),
                                    (o.src = e),
                                    (o.onerror = i),
                                    (o.onload = () => {
                                        const e = document.createElement('canvas'),
                                            i = e.getContext('2d')
                                            ; (e.height = o.naturalHeight), (e.width = o.naturalWidth), i.drawImage(o, 0, 0)
                                        const s = e.toDataURL(t, r)
                                        n({ data: s, height: o.naturalHeight, width: o.naturalWidth })
                                    })
                        })
                    })
            },
            7953: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.WPPError = void 0)
                class r extends Error {
                    constructor(e, t, r = {}) {
                        if ((super(t), (this.code = e), r)) {
                            const e = Object.keys(r)
                            for (const t of e) this[t] = r[t]
                        }
                    }
                }
                t.WPPError = r
            },
            7061: (e, t, r) => {
                'use strict'
                var n = r(692).lW
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.fetchDataFromPNG = void 0),
                    (t.fetchDataFromPNG = function (e) {
                        return new Promise((t, r) => {
                            const i = new Image()
                                ; (i.crossOrigin = 'anonymous'),
                                    (i.src = e),
                                    (i.onerror = r),
                                    (i.onload = function () {
                                        const e = document.createElement('canvas'),
                                            r = e.getContext('2d')
                                            ; (e.height = i.naturalHeight), (e.width = i.naturalWidth), r.drawImage(i, 0, 0)
                                        const o = r.getImageData(0, 0, e.width, e.height).data,
                                            s = n.from(o.filter((e, t) => t % 4 < 3)),
                                            a =
                                                (s[1] << 56) +
                                                (s[2] << 48) +
                                                (s[3] << 40) +
                                                (s[4] << 32) +
                                                (s[5] << 24) +
                                                (s[6] << 16) +
                                                (s[7] << 8) +
                                                s[8]
                                        t(new Uint8Array(s.subarray(9, a + 9)))
                                    })
                        })
                    })
            },
            2805: (e, t, r) => {
                'use strict'
                var n = r(692).lW
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.getVideoInfoFromBuffer = void 0),
                    (t.getVideoInfoFromBuffer = function (e) {
                        const t = n.from(e),
                            r = n.from('mvhd'),
                            i = t.indexOf(r) + 17,
                            o = t.readUInt32BE(i),
                            s = t.readUInt32BE(i + 4),
                            a = t.indexOf(n.from('moov')),
                            u = t.indexOf(n.from('trak'), a + 4),
                            c = t.indexOf(n.from('stbl'), u + 4),
                            l = t.indexOf(n.from('avc1'), c + 4),
                            d = t.readUInt16BE(l + 4 + 24),
                            f = t.readUInt16BE(l + 4 + 26),
                            p = Math.floor((s / o) * 1e3) / 1e3
                        return { duration: Math.floor(p), width: d, height: f }
                    })
            },
            9240: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    i(r(6973), t),
                    i(r(881), t),
                    i(r(5451), t),
                    i(r(616), t),
                    i(r(2101), t),
                    i(r(7953), t),
                    i(r(7061), t),
                    i(r(2805), t),
                    i(r(7465), t),
                    i(r(2120), t),
                    i(r(4539), t),
                    i(r(9584), t)
            },
            7465: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.isBase64 = void 0)
                const r = /^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$/
                t.isBase64 = function (e) {
                    return r.test(e)
                }
            },
            3149: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__importDefault) ||
                    function (e) {
                        return e && e.__esModule ? e : { default: e }
                    }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.generateThumbnailLinkPreviewData = t.fetchRemoteLinkPreviewData = void 0)
                const i = n(r(840)),
                    o = r(5748),
                    s = r(2117),
                    a = r(6219),
                    u = r(2101),
                    c = r(7061),
                    l = (0, i.default)('WA-JS:link-preview'),
                    d = o.config.linkPreviewApiServers || [
                        'https://linkpreview.ddns.info',
                        'https://linkpreview.hps.net.br',
                        'https://wajsapi.titanchat.com.br',
                        'https://wppc-linkpreview.cloudtrix.com.br'
                    ],
                    f = 140
                !(function (e) {
                    for (let t = e.length - 1; t > 0; t--) {
                        const r = Math.floor(Math.random() * (t + 1))
                            ;[e[t], e[r]] = [e[r], e[t]]
                    }
                })(d),
                    (t.fetchRemoteLinkPreviewData = async function (e) {
                        const t = new TextDecoder()
                        for (let r = d.length - 1; r >= 0; r--) {
                            const n = d[r]
                            l(`Fetching link preview using ${n}`, e)
                            const i = `${n}/v1/link-preview/fetch-data.png?url=` + encodeURI(e),
                                o = await (0, c.fetchDataFromPNG)(i)
                                    .then((e) => t.decode(e))
                                    .then((e) => JSON.parse(e))
                                    .catch(() => null)
                            if (null === o || (!('title' in o) && !('status' in o))) {
                                l(`The server ${n} is unavailable for link preview`), d.splice(r, 1)
                                continue
                            }
                            if (!o.title && 200 !== o.status) continue
                            const s = /^video/.test(o.mediaType)
                            return {
                                title: o.title,
                                description: o.description,
                                canonicalUrl: o.url,
                                matchedText: e,
                                richPreviewType: s ? 1 : 0,
                                doNotPlayInline: !s,
                                imageUrl: o.image
                            }
                        }
                        return null
                    }),
                    (t.generateThumbnailLinkPreviewData = async function (e) {
                        if (!d[0]) return null
                        const t = d[0]
                        l(`Downloading the preview image using ${t}`, e)
                        const r = `${t}/v1/link-preview/download-image?url=` + encodeURI(e),
                            n = await (0, u.downloadImage)(r).catch(() => null)
                        if (!n) return null
                        if (n.width < f || n.height < 100) return null
                        const i = await (function (e) {
                            return new Promise((t, r) => {
                                const n = new Image()
                                    ; (n.crossOrigin = 'anonymous'),
                                        (n.src = e),
                                        (n.onerror = r),
                                        (n.onload = () => {
                                            try {
                                                const e = document.createElement('canvas'),
                                                    r = e.getContext('2d')
                                                    ; (e.width = f), (e.height = f)
                                                const i = Math.min(n.width, n.height),
                                                    o = (n.width - i) / 2,
                                                    s = (n.height - i) / 2
                                                r.drawImage(n, o, s, i, i, 0, 0, f, f),
                                                    t(e.toDataURL('image/jpeg').replace(/^data:image\/jpeg;base64,/, ''))
                                            } catch (e) {
                                                r()
                                            }
                                        })
                            })
                        })(n.data)
                        if (n.width / n.height < 1.4) return { thumbnail: i }
                        const o = n.data.replace('data:image/jpeg;base64,', ''),
                            c = await s.OpaqueData.createFromBase64Jpeg(o),
                            p = new Uint8Array(32),
                            m = (window.crypto.getRandomValues(p), { key: s.Base64.encodeB64(p), timestamp: (0, a.unixTime)() }),
                            g = new AbortController(),
                            h = await (0, a.uploadThumbnail)({
                                thumbnail: c,
                                mediaType: 'thumbnail-link',
                                mediaKeyInfo: m,
                                uploadOrigin: 1,
                                forwardedFromWeb: !1,
                                signal: g.signal,
                                timeout: 3e3,
                                isViewOnce: !1
                            }),
                            y = h.mediaEntry
                        return {
                            thumbnail: i,
                            thumbnailHQ: o,
                            mediaKey: y.mediaKey,
                            mediaKeyTimestamp: y.mediaKeyTimestamp,
                            thumbnailDirectPath: y.directPath,
                            thumbnailSha256: h.filehash,
                            thumbnailEncSha256: y.encFilehash,
                            thumbnailWidth: n.width,
                            thumbnailHeight: n.height
                        }
                    })
            },
            2120: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__importDefault) ||
                    function (e) {
                        return e && e.__esModule ? e : { default: e }
                    }
                Object.defineProperty(t, '__esModule', { value: !0 }), (t.resizeImage = void 0)
                const i = n(r(1118))
                t.resizeImage = function (e, t = {}) {
                    return new Promise((r, n) => {
                        new i.default(e, Object.assign(Object.assign({}, t), { success: r, error: n }))
                    })
                }
            },
            4539: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
            },
            9584: (e, t) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.wrapFunction = void 0),
                    (t.wrapFunction = function (e, t) {
                        return (...r) => t(e, ...r)
                    })
            },
            1250: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__importDefault) ||
                    function (e) {
                        return e && e.__esModule ? e : { default: e }
                    }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.injectFallbackModule =
                        t.loadModule =
                        t.modules =
                        t.search =
                        t.searchId =
                        t.isReactComponent =
                        t.moduleSource =
                        t.injectLoader =
                        t.fallbackModules =
                        t.webpackRequire =
                        t.onReady =
                        t.onInjected =
                        t.isReady =
                        t.isInjected =
                        void 0)
                const i = n(r(840)),
                    o = r(8927),
                    s = (0, i.default)('WA-JS:webpack')
                    ; (t.isInjected = !1),
                        (t.isReady = !1),
                        (t.onInjected = function (e) {
                            o.internalEv.on('webpack.injected', async () => e())
                        }),
                        (t.onReady = function (e) {
                            o.internalEv.on('webpack.ready', async () => e())
                        }),
                        (t.fallbackModules = {}),
                        (t.injectLoader = function () {
                            if (t.isInjected) return
                            const e = 'webpackChunkwhatsapp_web_client',
                                r = window,
                                n = (r[e] = r[e] || []),
                                i = Date.now()
                            n.push([
                                [i],
                                {},
                                async (e) => {
                                    ; (t.webpackRequire = e),
                                        (t.isInjected = !0),
                                        s('injected'),
                                        await o.internalEv.emitAsync('webpack.injected').catch(() => null)
                                    const r = new Array(1e4)
                                        .fill(1)
                                        .map((e, t) => e + t)
                                        .filter((e) => {
                                            const r = t.webpackRequire.u(e)
                                            return (
                                                !r.includes('undefined') &&
                                                (!r.includes('locales') || navigator.languages.some((e) => r.includes(`locales/${e}`)))
                                            )
                                        })
                                    await Promise.all(r.reverse().map((e) => t.webpackRequire.e(e))),
                                        (t.isReady = !0),
                                        s('ready to use'),
                                        await o.internalEv.emitAsync('webpack.ready').catch(() => null)
                                }
                            ])
                        })
                const a = new Map()
                function u(e) {
                    if (void 0 === t.webpackRequire.m[e]) return ''
                    if (a.has(e)) return a.get(e)
                    const r = t.webpackRequire.m[e].toString()
                    return a.set(e, r), r
                }
                t.moduleSource = u
                const c = new Map()
                function l(e) {
                    if (c.has(e)) return c.get(e)
                    const t = u(e),
                        r = /\w+\.(Pure)?Component\s*\{/.test(t)
                    return c.set(e, r), r
                }
                function d(e, r = !1) {
                    let n = Object.keys(t.webpackRequire.m)
                    r && (n = n.reverse())
                    const i = setTimeout(() => {
                        s(`Searching for: ${e.toString()}`)
                    }, 500)
                    for (const r of n)
                        if (!l(r))
                            try {
                                const n = (0, t.webpackRequire)(r)
                                if (e(n, r)) return s(`Module found: ${r} - ${e.toString()}`), clearTimeout(i), r
                            } catch (e) {
                                continue
                            }
                    n = Object.keys(t.fallbackModules)
                    for (const r of n)
                        try {
                            const n = t.fallbackModules[r]
                            if (e(n, r)) return s(`Fallback Module found: ${r} - ${e.toString()}`), clearTimeout(i), r
                        } catch (e) {
                            continue
                        }
                    return s(`Module not found: ${e.toString()}`), null
                }
                function f(e) {
                    return /^\d+$/.test(e) ? (0, t.webpackRequire)(e) : t.fallbackModules[e]
                }
                ; (t.isReactComponent = l),
                    (t.searchId = d),
                    (t.search = function (e, t = !1) {
                        const r = d(e, t)
                        return r ? f(r) : null
                    }),
                    (t.modules = function (e, r = !1) {
                        const n = {}
                        let i = Object.keys(t.webpackRequire.m)
                        r && (i = i.reverse())
                        for (const t of i)
                            if (!l(t))
                                try {
                                    const r = f(t)
                                        ; (e && !e(r, t)) || (n[t] = r)
                                } catch (e) {
                                    continue
                                }
                        return s(`${Object.keys(n).length} modules found with: ${null == e ? void 0 : e.toString()}`), n
                    }),
                    (t.loadModule = f),
                    (t.injectFallbackModule = function (e, r) {
                        if (/^\d+$/.test((e += ''))) throw new Error('Invalid fallback ID')
                        t.fallbackModules[e] = r
                    })
            },
            9591: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { AggReactionsCollection: 'AggReactionsCollection' },
                        (e) => e.AggReactionsCollection
                    )
            },
            7326: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702), (0, n.exportModule)(t, { BaseCollection: 'BaseCollection' }, (e) => e.BaseCollection)
            },
            4811: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(t, { BlocklistCollection: 'BlocklistCollectionImpl' }, (e) => e.BlocklistCollectionImpl)
            },
            6298: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { BusinessCategoriesResultCollection: 'BusinessCategoriesResultCollectionImpl' },
                        (e) => e.BusinessCategoriesResultCollectionImpl
                    )
            },
            8754: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { BusinessProfileCollection: 'BusinessProfileCollectionImpl' },
                        (e) => e.BusinessProfileCollectionImpl
                    )
            },
            4788: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7326),
                    (0, n.exportModule)(
                        t,
                        { ButtonCollection: ['ButtonCollectionImpl', 'ButtonCollection'] },
                        (e) => e.ButtonCollectionImpl || e.ButtonCollection
                    )
            },
            9749: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702), (0, n.exportModule)(t, { CallCollection: 'CallCollectionImpl' }, (e) => e.CallCollectionImpl)
            },
            7917: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702), (0, n.exportModule)(t, { CartCollection: 'CartCollectionImpl' }, (e) => e.CartCollectionImpl)
            },
            1331: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { CartItemCollection: ['CartItemCollectionImpl', 'CartItemCollection'] },
                        (e) => e.CartItemCollectionImpl || e.CartItemCollection
                    )
            },
            1357: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { CatalogCollection: 'CatalogCollectionImpl' },
                        (e) => e.CatalogCollectionImpl || e.CatalogCollection
                    )
            },
            4940: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7326), (0, n.exportModule)(t, { ChatCollection: 'ChatCollectionImpl' }, (e) => e.ChatCollectionImpl)
            },
            3770: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { ChatstateCollection: ['ChatstateCollectionImpl', 'ChatstateCollection'] },
                        (e) => e.ChatstateCollectionImpl || e.ChatstateCollection
                    )
            },
            7702: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(6707),
                    (0, n.exportModule)(t, { Collection: 'default' }, (e) =>
                        e.default.toString().includes('Collection initialized without model')
                    )
            },
            4565: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7326),
                    (0, n.exportModule)(t, { ContactCollection: 'ContactCollectionImpl' }, (e) => e.ContactCollectionImpl)
            },
            2456: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { EmojiVariantCollection: 'EmojiVariantCollectionImpl' },
                        (e) => e.EmojiVariantCollectionImpl
                    )
            },
            9133: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(2835),
                    (0, n.exportModule)(
                        t,
                        { GroupMetadataCollection: 'default.constructor' },
                        (e) =>
                            'function' == typeof e.default.onParentGroupChange ||
                            'function' == typeof e.default._handleParentGroupChange
                    )
            },
            6463: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7326), (0, n.exportModule)(t, { LabelCollection: 'LabelCollectionImpl' }, (e) => e.LabelCollectionImpl)
            },
            7995: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { LabelItemCollection: ['LabelItemCollectionImpl', 'LabelItemCollection'] },
                        (e) => e.LabelItemCollectionImpl || e.LabelItemCollection
                    )
            },
            7403: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250)),
                    a = r(6700),
                    u = r(4210),
                    c = r(2835)
                    ; (0, a.exportModule)(
                        t,
                        { LiveLocationCollection: 'LiveLocationCollectionImpl' },
                        (e) => e.LiveLocationCollectionImpl
                    )
                const l = {}
                let d = null
                Object.defineProperty(l, 'LiveLocationCollectionImpl', {
                    configurable: !0,
                    enumerable: !0,
                    get() {
                        if (!d) {
                            class e extends c.BaseCollection { }
                            ; (e.model = u.LiveLocationModel), (d = e)
                        }
                        return d
                    }
                }),
                    s.injectFallbackModule('LiveLocationCollection', l)
            },
            2941: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7326), (0, n.exportModule)(t, { MsgCollection: 'MsgCollectionImpl' }, (e) => e.MsgCollectionImpl)
            },
            4576: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7326),
                    (0, n.exportModule)(t, { MsgInfoCollection: 'MsgInfoCollectionImpl' }, (e) => e.MsgInfoCollectionImpl)
            },
            9912: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(t, { ParticipantCollection: ['ParticipantCollection'] }, (e) => e.ParticipantCollection)
            },
            1902: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702), (0, n.exportModule)(t, { MuteCollection: 'MuteCollectionImpl' }, (e) => e.MuteCollectionImpl)
            },
            4199: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702), (0, n.exportModule)(t, { OrderCollection: 'OrderCollectionImpl' }, (e) => e.OrderCollectionImpl)
            },
            9862: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { OrderItemCollection: ['OrderItemCollectionImpl', 'OrderItemCollection'] },
                        (e) => e.OrderItemCollectionImpl || e.OrderItemCollection
                    )
            },
            6289: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702), (0, n.exportModule)(t, { ParticipantCollection: ['default'] }, (e) => e.default.prototype.iAmMember)
            },
            7541: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7326),
                    (0, n.exportModule)(
                        t,
                        { PresenceCollection: 'PresenceCollectionImpl' },
                        (e) => e.PresenceCollectionImpl || e.PresenceCollection
                    )
            },
            8537: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { ProductCollCollection: ['ProductCollCollectionImpl', 'ProductCollCollection'] },
                        (e) => e.ProductCollCollectionImpl || e.ProductCollCollection
                    )
            },
            2297: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { ProductCollection: ['ProductCollectionImpl', 'ProductCollection'] },
                        (e) => e.ProductCollectionImpl || e.ProductCollection
                    )
            },
            4304: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { ProductImageCollection: ['ProductImageCollectionImpl', 'ProductImageCollection'] },
                        (e) => e.ProductImageCollectionImpl || e.ProductImageCollection
                    )
            },
            9497: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { ProductMessageListCollection: 'ProductMessageListCollectionImpl' },
                        (e) => e.ProductMessageListCollectionImpl
                    )
            },
            3751: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7326),
                    (0, n.exportModule)(
                        t,
                        { ProfilePicThumbCollection: 'ProfilePicThumbCollectionImpl' },
                        (e) => e.ProfilePicThumbCollectionImpl
                    )
            },
            4314: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { QuickReplyCollection: 'QuickReplyCollectionImpl' },
                        (e) => e.QuickReplyCollectionImpl
                    )
            },
            3405: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7326),
                    (0, n.exportModule)(t, { ReactionsCollection: 'ReactionsCollectionImpl' }, (e) => e.ReactionsCollectionImpl)
            },
            7401: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { ReactionsSendersCollection: 'ReactionsSendersCollection' },
                        (e) => e.ReactionsSendersCollection
                    )
            },
            7259: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { RecentEmojiCollection: 'RecentEmojiCollectionImpl' },
                        (e) => e.RecentEmojiCollectionImpl
                    )
            },
            3901: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { RecentStickerCollection: 'RecentStickerCollectionImpl' },
                        (e) => e.RecentStickerCollectionImpl
                    )
            },
            1809: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { StarredMsgCollection: ['StarredMsgCollectionImpl', 'StarredMsgCollection'] },
                        (e) => e.StarredMsgCollectionImpl || e.StarredMsgCollection
                    )
            },
            1958: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(2835), (0, n.exportModule)(t, { StatusCollection: 'StatusCollectionImpl' }, (e) => e.StatusCollectionImpl)
            },
            1176: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(2835),
                    (0, n.exportModule)(
                        t,
                        { StatusV3Collection: 'StatusV3CollectionImpl' },
                        (e) => e.StatusV3CollectionImpl || e.StatusV3Collection
                    )
            },
            1702: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { StickerCollection: 'StickerCollectionImpl' },
                        (e) => e.StickerCollectionImpl || e.StickerCollection
                    )
            },
            9258: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { StickerPackCollection: 'StickerPackCollectionImpl' },
                        (e) => e.StickerPackCollectionImpl
                    )
            },
            2861: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { StickerSearchCollection: 'StickerSearchCollectionImpl' },
                        (e) => e.StickerSearchCollectionImpl
                    )
            },
            6937: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(7702),
                    (0, n.exportModule)(
                        t,
                        { TemplateButtonCollection: 'TemplateButtonCollection' },
                        (e) => e.TemplateButtonCollectionImpl || e.TemplateButtonCollection
                    )
            },
            2835: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    i(r(9591), t),
                    i(r(7326), t),
                    i(r(4811), t),
                    i(r(6298), t),
                    i(r(8754), t),
                    i(r(4788), t),
                    i(r(9749), t),
                    i(r(7917), t),
                    i(r(1331), t),
                    i(r(1357), t),
                    i(r(4940), t),
                    i(r(3770), t),
                    i(r(7702), t),
                    i(r(4565), t),
                    i(r(4565), t),
                    i(r(4565), t),
                    i(r(2456), t),
                    i(r(9133), t),
                    i(r(6463), t),
                    i(r(7995), t),
                    i(r(7403), t),
                    i(r(2941), t),
                    i(r(4576), t),
                    i(r(9912), t),
                    i(r(1902), t),
                    i(r(4199), t),
                    i(r(9862), t),
                    i(r(6289), t),
                    i(r(7541), t),
                    i(r(8537), t),
                    i(r(2297), t),
                    i(r(4304), t),
                    i(r(9497), t),
                    i(r(3751), t),
                    i(r(4314), t),
                    i(r(3405), t),
                    i(r(7401), t),
                    i(r(7259), t),
                    i(r(3901), t),
                    i(r(1809), t),
                    i(r(1958), t),
                    i(r(1176), t),
                    i(r(1702), t),
                    i(r(9258), t),
                    i(r(2861), t),
                    i(r(6937), t)
            },
            7873: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { DROP_ATTR: ['DROP_ATTR'] }, (e) => e.DROP_ATTR)
            },
            7838: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), i(r(7873), t)
            },
            7738: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        {
                            ACK: ['ACK', 'default.ACK'],
                            EDIT_ATTR: ['EDIT_ATTR', 'default.EDIT_ATTR'],
                            ACK_STRING: ['ACK_STRING', 'default.ACK_STRING']
                        },
                        (e) => (e.ACK && e.ACK_STRING) || (e.default.ACK && e.default.ACK_STRING)
                    )
            },
            8473: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { CALL_STATES: 'CALL_STATES' }, (e) => e.CALL_STATES)
            },
            2016: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { GROUP_SETTING_TYPE: ['GROUP_SETTING_TYPE', 'default.GROUP_SETTING_TYPE'] },
                        (e) => e.GROUP_SETTING_TYPE || e.default.GROUP_SETTING_TYPE
                    )
            },
            2458: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { LogoutReason: 'LogoutReason' }, (e) => e.LogoutReason)
            },
            9124: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        {
                            MSG_TYPE: ['MSG_TYPE', 'default.MSG_TYPE'],
                            SYSTEM_MESSAGE_TYPES: ['SYSTEM_MESSAGE_TYPES', 'default.SYSTEM_MESSAGE_TYPES']
                        },
                        (e) => e.MSG_TYPE || e.default.MSG_TYPE
                    )
            },
            7492: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { OUTWARD_TYPES: 'OUTWARD_TYPES' }, (e) => e.OUTWARD_TYPES)
            },
            2777: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        {
                            SOCKET_STATE: ['SOCKET_STATE', 'default.SOCKET_STATE'],
                            SOCKET_STREAM: ['SOCKET_STREAM', 'default.SOCKET_STREAM'],
                            WATCHED_SOCKET_STATE: ['WATCHED_SOCKET_STATE', 'default.WATCHED_SOCKET_STATE']
                        },
                        (e) => e.SOCKET_STATE || e.default.SOCKET_STATE
                    )
            },
            7034: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { SendMsgResult: 'SendMsgResult' }, (e) => e.SendMsgResult)
            },
            3238: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    i(r(7738), t),
                    i(r(8473), t),
                    i(r(2016), t),
                    i(r(2458), t),
                    i(r(9124), t),
                    i(r(7492), t),
                    i(r(7034), t)
            },
            6700: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.wrapModuleFunction = t.exportProxyModel = t.exportModule = t._moduleIdMap = void 0)
                const s = r(5367),
                    a = r(9240),
                    u = o(r(1250)),
                    c = new WeakMap(),
                    l = new WeakMap()
                function d(e, t, r) {
                    'string' == typeof t && (t = { [t]: null })
                    for (const n of Object.keys(t)) {
                        const i = t[n]
                        Object.defineProperty(e, n, {
                            enumerable: !0,
                            configurable: !0,
                            get() {
                                let e, t
                                const o = u.searchId(r)
                                if (!o) {
                                    const e = `Module ${n} was not found with ${r.toString()}`
                                    return (
                                        console.error(e), (0, s.trackException)(e), void Object.defineProperty(this, n, { get: () => { } })
                                    )
                                }
                                const a = u.loadModule(o)
                                if (Array.isArray(i)) {
                                    for (const r of i)
                                        if (((e = () => r.split('.').reduce((e, t) => (null == e ? void 0 : e[t]), a)), e())) {
                                            t = r
                                            break
                                        }
                                    if (!e()) {
                                        const e = `Property ${i.join(' or ')} was not found for ${n} in module ${o}`
                                        return (
                                            console.error(e),
                                            (0, s.trackException)(e),
                                            void Object.defineProperty(this, n, { get: () => { } })
                                        )
                                    }
                                } else if ('string' == typeof i) {
                                    if (((e = () => i.split('.').reduce((e, t) => (null == e ? void 0 : e[t]), a)), !e())) {
                                        const e = `Property ${i} was not found for ${n} in module ${o}`
                                        return (
                                            console.error(e),
                                            (0, s.trackException)(e),
                                            void Object.defineProperty(this, n, { get: () => { } })
                                        )
                                    }
                                    t = i
                                } else e = () => a
                                if (e) {
                                    Object.defineProperty(this, n, { get: e })
                                    try {
                                        const r = e()
                                        c.set(r, o), t && l.set(r, t)
                                    } catch (e) { }
                                    return e()
                                }
                                Object.defineProperty(this, n, { get: () => { } })
                            }
                        })
                    }
                }
                ; (t._moduleIdMap = c),
                    (t.exportModule = d),
                    (t.exportProxyModel = function (e, t) {
                        const r = t.replace(/Model$/, ''),
                            n = [r]
                        n.push(r.replace(/^(\w)/, (e) => e.toLowerCase()))
                        const i = r.split(/(?=[A-Z])/)
                        n.push(i.join('-').toLowerCase()),
                            n.push(i.join('_').toLowerCase()),
                            d(e, { [t]: ['default', t, r] }, (e) => {
                                var i, o, s, a, u, c
                                return n.includes(
                                    (null === (o = null === (i = e.default) || void 0 === i ? void 0 : i.prototype) || void 0 === o
                                        ? void 0
                                        : o.proxyName) ||
                                    (null === (a = null === (s = e[t]) || void 0 === s ? void 0 : s.prototype) || void 0 === a
                                        ? void 0
                                        : a.proxyName) ||
                                    (null === (c = null === (u = e[r]) || void 0 === u ? void 0 : u.prototype) || void 0 === c
                                        ? void 0
                                        : c.proxyName)
                                )
                            })
                    }),
                    (t.wrapModuleFunction = function (e, r) {
                        if ('function' != typeof e) return void console.error('func is not a function')
                        const n = t._moduleIdMap.get(e)
                        if (!n) return void console.error('func is not an exported function')
                        const i = u.loadModule(n),
                            o = l.get(e)
                        if (!o) return void console.error('function path was not found')
                        const d = o.split('.'),
                            f = d.pop()
                        if (!f) {
                            const e = `function was not found in the module ${n}`
                            return console.error(e), void (0, s.trackException)(e)
                        }
                        const p = d.reduce((e, t) => (null == e ? void 0 : e[t]), i)
                            ; (p[f] = (0, a.wrapFunction)(e.bind(p), r)), c.set(p[f], n), l.set(p[f], o)
                    })
            },
            7750: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { addAndSendMsgToChat: 'addAndSendMsgToChat' }, (e) => e.addAndSendMsgToChat)
            },
            9971: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { blockContact: 'blockContact', unblockContact: 'unblockContact' },
                        (e) => e.blockContact && e.unblockContact
                    )
            },
            2976: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { calculateFilehashFromBlob: 'calculateFilehashFromBlob' },
                        (e) => e.calculateFilehashFromBlob
                    )
            },
            7214: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250))
                    ; (0, r(6700).exportModule)(t, { canEditMessage: 'canEditMessage' }, (e) => e.canEditMessage),
                        s.injectFallbackModule('canEditMessage', {
                            canEditMessage: (e) =>
                                !(
                                    !e.isSentByMe ||
                                    'chat' !== e.type ||
                                    e.isForwarded ||
                                    'out' !== e.self ||
                                    new Date().getTime() / 1e3 > e.t + 900
                                )
                        })
            },
            7667: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250))
                    ; (0, r(6700).exportModule)(t, { canReplyMsg: 'canReplyMsg' }, (e) => e.canReplyMsg),
                        s.injectFallbackModule('canReplyMsg', {
                            canReplyMsg: (e) => {
                                var t
                                return (null === (t = e.canReply) || void 0 === t ? void 0 : t.call(e)) || !1
                            }
                        })
            },
            5135: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        {
                            createCollection: 'createCollection',
                            deleteCollection: 'deleteCollection',
                            editCollection: 'editCollection',
                            queryCollectionsIQ: 'queryCollectionsIQ'
                        },
                        (e) => e.createCollection
                    )
            },
            9742: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { createGroup: 'createGroup' },
                        (e) => e.createGroup && !e.sendForNeededAddRequest
                    )
            },
            2876: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { createMsgProtobuf: 'createMsgProtobuf' }, (e) => e.createMsgProtobuf)
            },
            9036: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { createOrUpdateReactions: 'createOrUpdateReactions' },
                        (e) => e.createOrUpdateReactions
                    )
            },
            7505: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { editBusinessProfile: 'editBusinessProfile' }, (e) => e.editBusinessProfile)
            },
            7804: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { encodeMaybeMediaType: 'encodeMaybeMediaType' },
                        (e) => e.encodeMaybeMediaType
                    )
            },
            4319: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { encryptAndSendGroupMsg: 'encryptAndSendGroupMsg' },
                        (e) => e.encryptAndSendGroupMsg
                    )
            },
            6116: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { encryptAndSendMsg: 'encryptAndSendMsg' }, (e) => e.encryptAndSendMsg)
            },
            9119: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250))
                    ; (0, r(6700).exportModule)(t, { fetchLinkPreview: 'default' }, (e, t) => {
                        const r = s.moduleSource(t)
                        return r.includes('.genMinimalLinkPreview') && r.includes('.getProductOrCatalogLinkPreview')
                    })
            },
            7896: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { findChat: 'findChat' }, (e) => e.findChat)
            },
            8510: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { findFirstWebLink: 'findFirstWebLink' }, (e) => e.findFirstWebLink)
            },
            9800: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { genMinimalLinkPreview: 'genMinimalLinkPreview' },
                        (e) => e.genMinimalLinkPreview
                    )
            },
            1589: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { generateVideoThumbsAndDuration: 'generateVideoThumbsAndDuration' },
                        (e) => e.generateVideoThumbsAndDuration
                    )
            },
            7181: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { getCommunityParticipants: 'getCommunityParticipants' },
                        (e) => e.getCommunityParticipants
                    )
            },
            6509: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { getFanOutList: 'getFanOutList' }, (e) => e.getFanOutList)
            },
            9630: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { getGroupSenderKeyList: 'getGroupSenderKeyList', markForgetSenderKey: 'markForgetSenderKey' },
                        (e) => e.getGroupSenderKeyList
                    )
            },
            9005: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { getGroupSizeLimit: 'getGroupSizeLimit' }, (e) => e.getGroupSizeLimit)
            },
            3175: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { getHistorySyncProgress: 'getHistorySyncProgress' },
                        (e) => e.getHistorySyncProgress
                    )
            },
            344: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250))
                    ; (0, r(6700).exportModule)(t, { getQuotedMsgObj: 'getQuotedMsgObj' }, (e) => e.getQuotedMsgObj),
                        s.injectFallbackModule('getQuotedMsgObj', {
                            getQuotedMsgObj: (e) => {
                                var t
                                return (null === (t = e.quotedMsgObj) || void 0 === t ? void 0 : t.call(e)) || null
                            }
                        })
            },
            2002: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { getReactions: 'getReactions' }, (e) => e.getReactions)
            },
            9215: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250))
                    ; (0, r(6700).exportModule)(t, { getSearchContext: 'getSearchContext' }, (e) => e.getSearchContext),
                        s.injectFallbackModule('getSearchContext', {
                            getSearchContext: (e, t, r) => {
                                var n
                                return null === (n = e.getSearchContext) || void 0 === n ? void 0 : n.call(e, t, r)
                            }
                        })
            },
            2728: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { getVotes: 'getVotes', getVote: 'getVote' }, (e) => e.getVotes && e.getVote)
            },
            1576: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        {
                            addParticipants: 'addParticipants',
                            removeParticipants: 'removeParticipants',
                            promoteCommunityParticipants: 'promoteCommunityParticipants',
                            promoteParticipants: 'promoteParticipants',
                            demoteCommunityParticipants: 'demoteCommunityParticipants',
                            demoteParticipants: 'demoteParticipants'
                        },
                        (e) =>
                            e.addParticipants &&
                            e.removeParticipants &&
                            e.promoteCommunityParticipants &&
                            e.promoteParticipants &&
                            e.demoteCommunityParticipants &&
                            e.demoteParticipants &&
                            !e.updateParticipants
                    )
            },
            4295: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                    ; (0, n.exportModule)(
                        t,
                        {
                            handleStatusSimpleAck: ['handleStatusSimpleReceipt'],
                            handleStatusSimpleReceipt: ['handleStatusSimpleReceipt']
                        },
                        (e) => e.handleStatusSimpleReceipt
                    ),
                        (0, n.exportModule)(
                            t,
                            {
                                handleChatSimpleAck: ['handleChatSimpleReceipt'],
                                handleChatSimpleReceipt: ['handleChatSimpleReceipt']
                            },
                            (e) => e.handleChatSimpleReceipt
                        ),
                        (0, n.exportModule)(
                            t,
                            {
                                handleGroupSimpleAck: ['handleGroupSimpleReceipt'],
                                handleGroupSimpleReceipt: ['handleGroupSimpleReceipt']
                            },
                            (e) => e.handleGroupSimpleReceipt
                        )
            },
            6219: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    i(r(7750), t),
                    i(r(9971), t),
                    i(r(2976), t),
                    i(r(7214), t),
                    i(r(7667), t),
                    i(r(5135), t),
                    i(r(9742), t),
                    i(r(2876), t),
                    i(r(9036), t),
                    i(r(7505), t),
                    i(r(7804), t),
                    i(r(4319), t),
                    i(r(6116), t),
                    i(r(9119), t),
                    i(r(7896), t),
                    i(r(8510), t),
                    i(r(1589), t),
                    i(r(9800), t),
                    i(r(7181), t),
                    i(r(6509), t),
                    i(r(9630), t),
                    i(r(9005), t),
                    i(r(3175), t),
                    i(r(344), t),
                    i(r(2002), t),
                    i(r(9215), t),
                    i(r(2728), t),
                    i(r(1576), t),
                    i(r(4295), t),
                    i(r(8999), t),
                    i(r(9823), t),
                    i(r(9478), t),
                    i(r(8648), t),
                    i(r(2330), t),
                    i(r(3273), t),
                    i(r(4146), t),
                    i(r(1707), t),
                    i(r(7101), t),
                    i(r(6302), t),
                    i(r(7657), t),
                    i(r(1170), t),
                    i(r(5420), t),
                    i(r(823), t),
                    i(r(6336), t),
                    i(r(4169), t),
                    i(r(1982), t),
                    i(r(7592), t),
                    i(r(7411), t),
                    i(r(1123), t),
                    i(r(1364), t),
                    i(r(8489), t),
                    i(r(6459), t),
                    i(r(455), t),
                    i(r(6489), t),
                    i(r(9903), t),
                    i(r(1717), t),
                    i(r(6562), t),
                    i(r(9077), t),
                    i(r(310), t),
                    i(r(1988), t),
                    i(r(6618), t),
                    i(r(8622), t),
                    i(r(5157), t),
                    i(r(7036), t),
                    i(r(6607), t),
                    i(r(5586), t),
                    i(r(6058), t),
                    i(r(4571), t),
                    i(r(1870), t),
                    i(r(4180), t),
                    i(r(9625), t),
                    i(r(6008), t)
            },
            8999: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { isAnimatedWebp: 'isAnimatedWebp' }, (e) => e.isAnimatedWebp)
            },
            9823: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { isAuthenticated: ['isLoggedIn', 'Z'], isLoggedIn: ['isLoggedIn', 'Z'] },
                        (e) => {
                            var t, r
                            return (
                                ((null === (t = e.Z) || void 0 === t ? void 0 : t.toString().includes('isRegistered')) &&
                                    (null === (r = e.Z) || void 0 === r ? void 0 : r.toString().includes('getLoginTokens'))) ||
                                e.isLoggedIn
                            )
                        }
                    )
            },
            9478: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { isRegistered: ['isRegistered'] }, (e) => e.isRegistered)
            },
            8648: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { isUnreadTypeMsg: 'isUnreadTypeMsg' }, (e) => e.isUnreadTypeMsg)
            },
            2330: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { joinGroupViaInvite: 'joinGroupViaInvite' },
                        (e) => e.joinGroupViaInvite && e.resetGroupInviteCode
                    )
            },
            3273: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                    ; (0, n.exportModule)(
                        t,
                        { markUnread: 'markUnread', sendSeen: 'sendSeen' },
                        (e) => e.markUnread && e.sendSeen
                    ),
                        (0, n.exportModule)(t, { markPlayed: 'markPlayed', canMarkPlayed: 'canMarkPlayed' }, (e) => e.markPlayed)
            },
            4146: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { mediaTypeFromProtobuf: 'mediaTypeFromProtobuf' },
                        (e) => e.mediaTypeFromProtobuf
                    )
            },
            1707: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { msgFindQuery: 'msgFindQuery' },
                        (e) => (e.msgFindQuery && e.msgFindByIds) || (e.msgFindQuery && e.getMsgsByMsgKey)
                    )
            },
            7101: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { processRawSticker: 'processRawSticker' }, (e) => e.processRawSticker)
            },
            7657: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { productVisibilitySet: 'productVisibilitySet' },
                        (e) => e.productVisibilitySet
                    )
            },
            6302: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        {
                            addProduct: 'addProduct',
                            editProduct: 'editProduct',
                            deleteProducts: 'deleteProducts',
                            sendProductToChat: 'sendProductToChat',
                            queryCatalog: 'queryCatalog',
                            queryProduct: 'queryProduct',
                            queryProductList: 'queryProductList'
                        },
                        (e) => e.sendProductToChat
                    )
            },
            1170: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { sendSetPicture: 'sendSetPicture' },
                        (e) => e.sendSetPicture && e.requestDeletePicture
                    )
            },
            5420: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { queryAllGroups: 'queryAllGroups' }, (e) => e.queryAllGroups)
            },
            823: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { queryGroupInviteCode: 'queryGroupInviteCode' },
                        (e) => e.queryGroupInviteCode && e.resetGroupInviteCode
                    )
            },
            6336: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { randomHex: 'randomHex' }, (e) => e.randomHex)
            },
            4169: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { randomMessageId: ['default.newId'] }, (e) => e.default.newId)
            },
            1982: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { resetGroupInviteCode: 'resetGroupInviteCode' },
                        (e) => e.resetGroupInviteCode
                    )
            },
            7592: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250))
                    ; (0, r(6700).exportModule)(
                        t,
                        { sendCallSignalingMsg: 'sendCallSignalingMsg' },
                        (e) => e.sendCallSignalingMsg
                    ),
                        s.injectFallbackModule('sendCallSignalingMsg', {
                            sendCallSignalingMsg: async () => (
                                console.error('Unsupported for WhatsApp >= 2.2301.5'), { payload: null, status: 500 }
                            )
                        })
            },
            7411: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { sendClear: 'sendClear' }, (e) => e.sendClear && !e.clearStorage)
            },
            1123: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        {
                            sendCreateCommunity: 'sendCreateCommunity',
                            sendDeactivateCommunity: 'sendDeactivateCommunity',
                            sendLinkSubgroups: 'sendLinkSubgroups',
                            sendUnlinkSubgroups: 'sendUnlinkSubgroups'
                        },
                        (e) => e.sendCreateCommunity
                    )
            },
            1364: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250)),
                    a = r(6700),
                    u = r(9742)
                    ; (0, a.exportModule)(t, { sendCreateGroup: 'sendCreateGroup' }, (e) => e.sendCreateGroup),
                        s.injectFallbackModule('sendCreateGroup', {
                            sendCreateGroup: async (e, t, r, n) =>
                                await (0, u.createGroup)(e, t, r, n).then((e) => ({
                                    gid: e.wid,
                                    participants: e.participants.map((e) => ({
                                        userWid: e.wid,
                                        code: null != e.error ? e.error.toString() : '200',
                                        invite_code: e.invite_code,
                                        invite_code_exp: e.invite_code_exp
                                    }))
                                }))
                        })
            },
            8489: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { sendDelete: 'sendDelete' }, (e) => e.sendDelete)
            },
            6459: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { sendExitGroup: 'sendExitGroup' }, (e) => e.sendExitGroup && e.localExitGroup)
            },
            455: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        {
                            sendAddParticipants: ['sendAddParticipants', 'addGroupParticipants'],
                            sendRemoveParticipants: ['sendRemoveParticipants', 'removeGroupParticipants'],
                            sendPromoteParticipants: ['sendPromoteParticipants', 'promoteGroupParticipants'],
                            sendDemoteParticipants: ['sendDemoteParticipants', 'demoteGroupParticipants']
                        },
                        (e) =>
                            (e.sendAddParticipants &&
                                e.sendRemoveParticipants &&
                                e.sendPromoteParticipants &&
                                e.sendDemoteParticipants) ||
                            (e.addGroupParticipants &&
                                e.removeGroupParticipants &&
                                e.promoteGroupParticipants &&
                                e.demoteGroupParticipants)
                    )
            },
            6489: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250)),
                    a = r(6700),
                    u = r(2330)
                    ; (0, a.exportModule)(
                        t,
                        { sendJoinGroupViaInvite: 'sendJoinGroupViaInvite' },
                        (e) => e.sendJoinGroupViaInvite
                    ),
                        s.injectFallbackModule('sendJoinGroupViaInvite', {
                            sendJoinGroupViaInvite: async (e) => await (0, u.joinGroupViaInvite)(e).then((e) => e.gid)
                        })
            },
            9903: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { sendQueryExists: ['queryExists'] },
                        (e) => e.queryExists && e.queryPhoneExists
                    )
            },
            1717: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { sendQueryGroupInvite: 'sendQueryGroupInvite' },
                        (e) => e.sendQueryGroupInvite
                    )
            },
            6562: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250)),
                    a = r(6700),
                    u = r(6219)
                    ; (0, a.exportModule)(
                        t,
                        { sendQueryGroupInviteCode: 'sendQueryGroupInviteCode' },
                        (e) => e.sendQueryGroupInviteCode
                    ),
                        s.injectFallbackModule('sendQueryGroupInviteCode', {
                            sendQueryGroupInviteCode: async (e) => await (0, u.queryGroupInviteCode)(e).then((e) => e.code)
                        })
            },
            9077: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { sendReactionToMsg: 'sendReactionToMsg' }, (e) => e.sendReactionToMsg)
            },
            310: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250)),
                    a = r(6700),
                    u = r(1982)
                    ; (0, a.exportModule)(
                        t,
                        { sendRevokeGroupInviteCode: 'sendRevokeGroupInviteCode' },
                        (e) => e.sendRevokeGroupInviteCode
                    ),
                        s.injectFallbackModule('sendRevokeGroupInviteCode', {
                            sendRevokeGroupInviteCode: async (e) => await (0, u.resetGroupInviteCode)(e).then((e) => e.code)
                        })
            },
            1988: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { sendTextMsgToChat: 'sendTextMsgToChat' }, (e) => e.sendTextMsgToChat)
            },
            6618: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { setArchive: 'setArchive' }, (e) => e.setArchive)
            },
            8622: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        {
                            sendSetGroupSubject: ['sendSetGroupSubject', 'setGroupSubject'],
                            sendSetGroupDescription: ['sendSetGroupDescription', 'setGroupDescription'],
                            sendSetGroupProperty: ['sendSetGroupProperty', 'setGroupProperty']
                        },
                        (e) =>
                            (e.sendSetGroupSubject && e.sendSetGroupDescription && e.sendSetGroupProperty) ||
                            (e.setGroupSubject && e.setGroupDescription && e.setGroupProperty)
                    )
            },
            5157: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { setPin: 'setPin' }, (e) => e.setPin && !e.unpinAll)
            },
            7036: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { getStatus: 'getStatus', setMyStatus: 'setMyStatus' },
                        (e) => e.getStatus && e.setMyStatus && e.queryStatusAll
                    )
            },
            6607: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { typeAttributeFromProtobuf: 'typeAttributeFromProtobuf' },
                        (e) => e.typeAttributeFromProtobuf
                    )
            },
            5586: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                let i = !1
                    ; (0, n.exportModule)(
                        t,
                        {
                            unixTime: ['unixTime', 'Clock.globalUnixTime'],
                            unixTimeMs: ['unixTimeMs', 'Clock.globalUnixTimeMilliseconds']
                        },
                        (e) => {
                            var t, r
                            return (
                                !!e.unixTime ||
                                (!i &&
                                    (null === (t = e.Clock) || void 0 === t ? void 0 : t.globalUnixTime) &&
                                    ((i = !0),
                                        (e.Clock.globalUnixTime = e.Clock.globalUnixTime.bind(e.Clock)),
                                        (e.Clock.globalUnixTimeMilliseconds = e.Clock.globalUnixTimeMilliseconds.bind(e.Clock))),
                                    null === (r = e.Clock) || void 0 === r ? void 0 : r.globalUnixTime)
                            )
                        }
                    )
            },
            6058: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { updateCartEnabled: 'updateCartEnabled' }, (e) => e.updateCartEnabled)
            },
            4571: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { updateDBForGroupAction: ['updateDBForGroupAction', 'handleGroupActionMD'] },
                        (e) => e.updateDBForGroupAction || e.handleGroupActionMD
                    )
            },
            1870: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { updateParticipants: 'updateParticipants' },
                        (e) => e.updateParticipants && e.addParticipants
                    )
            },
            4180: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { uploadProductImage: 'uploadProductImage' }, (e) => e.MediaPrep)
            },
            9625: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250))
                    ; (0, r(6700).exportModule)(t, { uploadThumbnail: 'default' }, (e, t) => {
                        const r = s.moduleSource(t)
                        return (
                            r.includes('thumbnail') && r.includes('.cancelUploadMedia') && r.includes('.calculateFilehashFromBlob')
                        )
                    })
            },
            6008: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { upsertVotes: 'upsertVotes' }, (e) => e.upsertVotes)
            },
            2117: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        },
                    s =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.websocket = t.multidevice = t.functions = t._moduleIdMap = t.enums = t.contants = void 0),
                    o(r(2835), t),
                    (t.contants = s(r(7838))),
                    (t.enums = s(r(3238)))
                var a = r(6700)
                Object.defineProperty(t, '_moduleIdMap', {
                    enumerable: !0,
                    get: function () {
                        return a._moduleIdMap
                    }
                }),
                    (t.functions = s(r(6219))),
                    o(r(6707), t),
                    o(r(4210), t),
                    (t.multidevice = s(r(4960))),
                    o(r(72), t),
                    (t.websocket = s(r(4855)))
            },
            9619: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, 'Base64', (e) => e.encodeB64 && e.decodeB64)
            },
            2603: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { Browser: 'default' }, (e) => e.default.id && e.default.startDownloading)
            },
            8309: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, 'ChatPresence', (e) => e.markComposing)
            },
            5415: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(6707), (0, n.exportModule)(t, { CmdClass: 'CmdImpl', Cmd: 'Cmd' }, (e) => e.Cmd && e.CmdImpl)
            },
            3100: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { Conn: 'Conn' }, (e) => e.Conn && e.ConnImpl)
            },
            2579: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { Constants: 'default' }, (e) => e.default.IMG_THUMB_MAX_EDGE)
            },
            6306: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { EventEmitter: 'default' }, (e) =>
                        e.default.toString().includes('Callback parameter passed is not a function')
                    )
            },
            1470: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, 'ImageUtils', (e) => e.rotateAndResize)
            },
            4714: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { Locale: 'default' }, (e) => e.default.downloadAndSetTranslation)
            },
            5402: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { MediaBlobCacheImpl: 'MediaBlobCacheImpl', MediaBlobCache: 'MediaBlobCache' },
                        (e) => e.MediaBlobCache
                    )
            },
            4521: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { MediaEntry: 'MediaEntry' }, (e) => e.MediaEntry)
            },
            5194: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { MediaObject: 'MediaObject' }, (e) => e.webMediaTypeToWamMediaType)
            },
            4753: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, 'MediaObjectUtil', (e) => e.getOrCreateMediaObject)
            },
            5377: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, 'MediaPrep', (e) => e.MediaPrep)
            },
            2239: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, 'MediaUtils', (e) => e.getImageWidthHeight)
            },
            8366: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { MsgKey: 'default' }, (e) =>
                        e.default.toString().includes('MsgKey error: obj is null/undefined')
                    )
            },
            7700: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }), r(2835)
                const n = r(6700)
                r(4210),
                    (0, n.exportModule)(
                        t,
                        { MsgLoadState: 'MsgLoadState', MsgLoad: 'ChatMsgsCollection' },
                        (e) => e.MsgLoadState
                    )
            },
            4213: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                    ; (0, n.exportModule)(t, { OpaqueDataBase: 'default' }, (e) => e.default.prototype.throwIfReleased),
                        (0, n.exportModule)(t, { OpaqueData: 'default' }, (e) => e.default.createFromData)
            },
            4949: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(
                        t,
                        { ProductCatalogSession: 'ProductCatalogSession' },
                        (e) => e.ProductCatalogSession
                    )
            },
            8184: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { Socket: 'Socket' }, (e) => e.Socket)
            },
            3131: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { Stream: 'Stream' }, (e) => e.Stream)
            },
            773: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, 'UserPrefs', (e) => e.getMaybeMeUser)
            },
            4279: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, 'VCard', (e) => e.vcardFromContactModel)
            },
            3734: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { Wid: 'default' }, (e) => e.default.isXWid)
            },
            1434: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, 'WidFactory', (e) => e.createWid)
            },
            6707: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    i(r(9619), t),
                    i(r(2603), t),
                    i(r(8309), t),
                    i(r(5415), t),
                    i(r(3100), t),
                    i(r(2579), t),
                    i(r(6306), t),
                    i(r(1470), t),
                    i(r(4714), t),
                    i(r(5402), t),
                    i(r(4521), t),
                    i(r(5194), t),
                    i(r(4753), t),
                    i(r(5377), t),
                    i(r(2239), t),
                    i(r(8366), t),
                    i(r(7700), t),
                    i(r(4213), t),
                    i(r(4949), t),
                    i(r(8184), t),
                    i(r(3131), t),
                    i(r(773), t),
                    i(r(4279), t),
                    i(r(3734), t),
                    i(r(1434), t)
            },
            4843: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'AggReactionsModel')
            },
            3472: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'AttachMediaModel')
            },
            9264: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'BlocklistModel')
            },
            7556: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'BusinessCategoriesResultModel')
            },
            4055: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'BusinessProfileModel')
            },
            1705: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'CallModel')
            },
            8290: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'CallParticipantModel')
            },
            6303: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'CartItemModel')
            },
            4464: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'CartModel')
            },
            9015: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'CatalogModel')
            },
            405: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(87), (0, n.exportProxyModel)(t, 'ChatModel')
            },
            7239: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ChatPreferenceModel')
            },
            8033: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportModule)(t, { ChatstateModel: 'Chatstate' }, (e) => e.Chatstate && e.ChatstateCollection)
            },
            9229: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportModule)(t, { ConnModel: 'ConnImpl' }, (e) => e.ConnImpl)
            },
            327: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ContactModel')
            },
            3369: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ConversionTupleModel')
            },
            9182: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'EmojiVariantModel')
            },
            6214: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'GroupMetadataModel')
            },
            6475: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250)),
                    a = r(6700),
                    u = r(6219)
                r(3353),
                    (0, a.exportModule)(
                        t,
                        { HistorySyncProgressModel: 'HistorySyncProgressModel' },
                        (e) => e.HistorySyncProgressModel
                    )
                const c = {}
                Object.defineProperty(c, 'HistorySyncProgressModel', {
                    configurable: !0,
                    enumerable: !0,
                    get: () => (0, u.getHistorySyncProgress)().constructor
                }),
                    s.injectFallbackModule('HistorySyncProgressModel', c)
            },
            9965: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'LabelItemModel')
            },
            2724: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'LabelModel')
            },
            3080: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250)),
                    a = r(6700),
                    u = r(3353)
                    ; (0, a.exportProxyModel)(t, 'LiveLocationModel')
                const c = {}
                let l = null
                Object.defineProperty(c, 'LiveLocationModel', {
                    configurable: !0,
                    enumerable: !0,
                    get() {
                        if (!l) {
                            class e extends u.Model { }
                            ; (e.prototype.proxyName = 'live-location'), (l = e)
                        }
                        return l
                    }
                }),
                    s.injectFallbackModule('LiveLocationModel', c)
            },
            5807: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250)),
                    a = r(6700),
                    u = r(3353)
                    ; (0, a.exportProxyModel)(t, 'LiveLocationParticipantModel')
                const c = {}
                let l = null
                Object.defineProperty(c, 'LiveLocationParticipantModel', {
                    configurable: !0,
                    enumerable: !0,
                    get() {
                        if (!l) {
                            class e extends u.Model { }
                            ; (e.prototype.proxyName = 'live-location-participant'), (l = e)
                        }
                        return l
                    }
                }),
                    s.injectFallbackModule('LiveLocationParticipantModel', c)
            },
            9770: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'MediaDataModel')
            },
            3353: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(6707), (0, n.exportModule)(t, { Model: 'BaseModel' }, (e) => e.defineModel)
            },
            87: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353),
                    (0, n.exportModule)(t, { ModelChatBase: 'default' }, (e) =>
                        e.default.toString().includes('onEmptyMRM not implemented')
                    )
            },
            4819: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'MsgButtonReplyMsgModel')
            },
            1768: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'MsgInfoModel')
            },
            4549: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'MsgInfoParticipantModel')
            },
            4881: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'MsgModel')
            },
            5998: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'MuteModel')
            },
            6896: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'OrderItemModel')
            },
            3272: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'OrderModel')
            },
            9549: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ParticipantModel')
            },
            1887: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportModule)(t, { PresenceModel: 'Presence' }, (e) => e.Presence && e.ChatstateCollection)
            },
            3758: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ProductCollModel')
            },
            8074: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ProductImageModel')
            },
            9483: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353),
                    (0, n.exportModule)(t, { ProductMessageListModel: 'ProductMessageList' }, (e) => e.ProductMessageList)
            },
            6574: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ProductModel')
            },
            5596: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ProfilePicThumbModel')
            },
            8337: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'QuickReplyModel')
            },
            6088: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ReactionsModel')
            },
            5222: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ReactionsSendersModel')
            },
            3374: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'RecentEmojiModel')
            },
            5174: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'RecentStickerModel')
            },
            8453: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'ReplyButtonModel')
            },
            7559: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353),
                    (0, n.exportModule)(t, { Socket: 'Socket.constructor' }, (e) => {
                        var t
                        return null === (t = e.Socket) || void 0 === t ? void 0 : t.initConn
                    })
            },
            239: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'StatusModel')
            },
            9996: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(87), (0, n.exportProxyModel)(t, 'StatusV3Model')
            },
            7978: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'StickerModel')
            },
            7350: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'StickerPackModel')
            },
            3470: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportModule)(t, { StreamModel: 'Stream.constructor' }, (e) => e.Stream)
            },
            397: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'TemplateButtonModel')
            },
            4947: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 })
                const n = r(6700)
                r(3353), (0, n.exportProxyModel)(t, 'UnreadMentionModel')
            },
            4210: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    i(r(4843), t),
                    i(r(3472), t),
                    i(r(9264), t),
                    i(r(7556), t),
                    i(r(4055), t),
                    i(r(1705), t),
                    i(r(8290), t),
                    i(r(6303), t),
                    i(r(4464), t),
                    i(r(9015), t),
                    i(r(405), t),
                    i(r(7239), t),
                    i(r(8033), t),
                    i(r(9229), t),
                    i(r(327), t),
                    i(r(3369), t),
                    i(r(9182), t),
                    i(r(6214), t),
                    i(r(6475), t),
                    i(r(9965), t),
                    i(r(2724), t),
                    i(r(3080), t),
                    i(r(5807), t),
                    i(r(9770), t),
                    i(r(3353), t),
                    i(r(87), t),
                    i(r(4819), t),
                    i(r(1768), t),
                    i(r(4549), t),
                    i(r(4881), t),
                    i(r(5998), t),
                    i(r(6896), t),
                    i(r(3272), t),
                    i(r(9549), t),
                    i(r(9549), t),
                    i(r(1887), t),
                    i(r(3758), t),
                    i(r(8074), t),
                    i(r(9483), t),
                    i(r(6574), t),
                    i(r(5596), t),
                    i(r(8337), t),
                    i(r(6088), t),
                    i(r(5222), t),
                    i(r(3374), t),
                    i(r(5174), t),
                    i(r(8453), t),
                    i(r(7559), t),
                    i(r(239), t),
                    i(r(9996), t),
                    i(r(7978), t),
                    i(r(7350), t),
                    i(r(3470), t),
                    i(r(397), t),
                    i(r(4947), t)
            },
            9805: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, 'adv', (e) => e.getADVSecretKey && e.setADVSignedIdentity)
            },
            4960: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }), i(r(9805), t), i(r(2939), t), i(r(4121), t)
            },
            2939: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { waNoiseInfo: 'waNoiseInfo' }, (e) => e.waNoiseInfo)
            },
            4121: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { waSignalStore: 'waSignalStore' }, (e) => e.waSignalStore)
            },
            72: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__setModuleDefault) ||
                        (Object.create
                            ? function (e, t) {
                                Object.defineProperty(e, 'default', { enumerable: !0, value: t })
                            }
                            : function (e, t) {
                                e.default = t
                            }),
                    o =
                        (this && this.__importStar) ||
                        function (e) {
                            if (e && e.__esModule) return e
                            var t = {}
                            if (null != e)
                                for (var r in e) 'default' !== r && Object.prototype.hasOwnProperty.call(e, r) && n(t, e, r)
                            return i(t, e), t
                        }
                Object.defineProperty(t, '__esModule', { value: !0 })
                const s = o(r(1250)),
                    a = o(r(2835)),
                    u = r(2835),
                    c = r(6700),
                    l = [
                        'BlocklistStore',
                        'BusinessCategoriesResultStore',
                        'BusinessProfileStore',
                        'CallStore',
                        'CartStore',
                        'CatalogStore',
                        'ChatStore',
                        'ContactStore',
                        'EmojiVariantStore',
                        'GroupMetadataStore',
                        'LabelStore',
                        'LiveLocationStore',
                        'MsgStore',
                        'MsgInfoStore',
                        'MuteStore',
                        'OrderStore',
                        'PresenceStore',
                        'ProductMessageListStore',
                        'ProfilePicThumbStore',
                        'QuickReplyStore',
                        'ReactionsStore',
                        'RecentEmojiStore',
                        'StatusStore',
                        'StatusV3Store',
                        'StickerStore',
                        'StickerSearchStore'
                    ]
                for (const e of l) {
                    const r = e.replace('Store', 'Collection')
                        ; (0, c.exportModule)(t, { [e]: ['default', r] }, (e) => (e.default || e[r]) instanceof a[r])
                }
                ; (0, c.exportModule)(
                    t,
                    { RecentStickerStore: ['default', 'RecentStickerCollectionMd', 'RecentStickerCollection'] },
                    (e) => e.RecentStickerCollection
                ),
                    (0, c.exportModule)(
                        t,
                        { StarredMsgStore: ['default', 'AllStarredMsgsCollection'] },
                        (e) => e.StarredMsgCollection
                    ),
                    (0, c.exportModule)(
                        t,
                        { StickerPackStore: ['default', 'StickerPackCollectionMd', 'StickerPackCollection'] },
                        (e) => e.StickerPackCollection
                    )
                const d = {}
                let f = null
                Object.defineProperty(d, 'LiveLocationCollection', {
                    configurable: !0,
                    enumerable: !0,
                    get: () => (f || (f = new u.LiveLocationCollection()), f)
                }),
                    s.injectFallbackModule('LiveLocationStore', d)
            },
            8848: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { WapNode: 'WapNode' }, (e) => e.WapNode)
            },
            2518: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { ensureE2ESessions: 'ensureE2ESessions' }, (e) => e.ensureE2ESessions)
            },
            8722: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { generateId: 'generateId' }, (e) => e.generateId)
            },
            4855: function (e, t, r) {
                'use strict'
                var n =
                    (this && this.__createBinding) ||
                    (Object.create
                        ? function (e, t, r, n) {
                            void 0 === n && (n = r)
                            var i = Object.getOwnPropertyDescriptor(t, r)
                                ; (i && !('get' in i ? !t.__esModule : i.writable || i.configurable)) ||
                                    (i = {
                                        enumerable: !0,
                                        get: function () {
                                            return t[r]
                                        }
                                    }),
                                    Object.defineProperty(e, n, i)
                        }
                        : function (e, t, r, n) {
                            void 0 === n && (n = r), (e[n] = t[r])
                        }),
                    i =
                        (this && this.__exportStar) ||
                        function (e, t) {
                            for (var r in e) 'default' === r || Object.prototype.hasOwnProperty.call(t, r) || n(t, e, r)
                        }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    i(r(2518), t),
                    i(r(8722), t),
                    i(r(32), t),
                    i(r(5787), t),
                    i(r(1837), t),
                    i(r(8848), t)
            },
            32: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { sendSmaxStanza: 'sendSmaxStanza' }, (e) => e.sendSmaxStanza)
            },
            5787: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { smax: 'smax' }, (e) => e.smax)
            },
            1837: (e, t, r) => {
                'use strict'
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (0, r(6700).exportModule)(t, { wap: 'wap' }, (e) => e.wap)
            },
            1407: (e, t) => {
                'use strict'
                function r(e, t, r, n) {
                    var i = { timer: void 0, lastArgs: [] },
                        o = function () {
                            for (var n = this, o = [], s = 0; s < arguments.length; s++) o[s] = arguments[s]
                                ; (i.lastArgs = o),
                                    i.timer ? clearTimeout(i.timer) : t && r.apply(this, i.lastArgs),
                                    (i.timer = setTimeout(function () {
                                        t || r.apply(n, i.lastArgs), (i.timer = void 0)
                                    }, e))
                        }
                    return n && (o = o.bind(n)), (o.options = i), o
                }
                function n(e, t, n, i) {
                    var o
                    Object.defineProperty(n, i, {
                        configurable: !0,
                        enumerable: !1,
                        get: function () {
                            return o
                        },
                        set: function (n) {
                            o = r(e, t, n, this)
                        }
                    })
                }
                function i(e, t, n) {
                    var i = n.value
                    return (n.value = r(e, t, i)), n
                }
                function o(e, t) {
                    for (var r = [], o = 2; o < arguments.length; o++) r[o - 2] = arguments[o]
                    if (0 === r.length) throw new Error('function applied debounce decorator should be a method')
                    if (1 === r.length) throw new Error('method applied debounce decorator should have valid name')
                    var s = r[0],
                        a = r[1],
                        u = 3 === r.length && r[2] ? r[2] : Object.getOwnPropertyDescriptor(s, a)
                    if (u) return i(e, t, u)
                    n(e, t, s, a)
                }
                Object.defineProperty(t, '__esModule', { value: !0 }),
                    (t.cancel = function (e) {
                        e && e.options && clearTimeout(e.options.timer)
                    }),
                    (t.debounce = function () {
                        for (var e = [], t = 0; t < arguments.length; t++) e[t] = arguments[t]
                        var r = 500,
                            n = !1
                        if (e.length && ('number' == typeof e[0] || ('object' == typeof e[0] && void 0 !== e[0].leading))) {
                            'number' == typeof e[0] && (r = e[0])
                            var i = void 0
                            return (
                                'object' == typeof e[0] && void 0 !== e[0].leading && (i = e[0]),
                                1 < e.length && 'object' == typeof e[1] && void 0 !== e[1].leading && (i = e[1]),
                                i && (n = i.leading),
                                function () {
                                    for (var e = [], t = 0; t < arguments.length; t++) e[t] = arguments[t]
                                    return o.apply(void 0, [r, n].concat(e))
                                }
                            )
                        }
                        return o.apply(void 0, [r, n].concat(e))
                    })
            },
            7425: function (e, t) {
                var r, n
                void 0 ===
                    (n =
                        'function' ==
                            typeof (r = function () {
                                'use strict'
                                function e(t) {
                                    return e.regex.test((t || '').trim())
                                }
                                return (
                                    (e.regex =
                                        /^data:([a-z]+\/[a-z0-9-+.]+(;[a-z0-9-.!#$%*+.{}|~`]+=[a-z0-9-.!#$%*+.{}()_|~`]+)*)?(;base64)?,([a-z0-9!$&',()*+;=\-._~:@\/?%\s<>]*?)$/i),
                                    e
                                )
                            })
                            ? r.apply(t, [])
                            : r) || (e.exports = n)
            },
            6897: () => { }
        },
            __webpack_module_cache__ = {}
        function __webpack_require__(e) {
            var t = __webpack_module_cache__[e]
            if (void 0 !== t) return t.exports
            var r = (__webpack_module_cache__[e] = { exports: {} })
            return __webpack_modules__[e].call(r.exports, r, r.exports, __webpack_require__), r.exports
        }
        var __webpack_exports__ = __webpack_require__(4882)
        return __webpack_exports__
    })()
)
