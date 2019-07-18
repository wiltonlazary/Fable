import Event from "./Event";
import { IDisposable } from "./Util";

export default class Timer implements IDisposable {
  public Interval: number;
  public AutoReset: boolean;

  private _elapsed: Event<Date>;
  private _enabled: boolean;
  private _isDisposed: boolean;
  private _intervalId: number;
  private _timeoutId: number;

  constructor(interval?: number) {
    this.Interval = interval > 0 ? interval : 100;
    this.AutoReset = true;
    this._elapsed = new Event<Date>();
  }

  get Elapsed() {
    return this._elapsed;
  }

  get Enabled() {
    return this._enabled;
  }

  set Enabled(x: boolean) {
    if (!this._isDisposed && this._enabled !== x) {
      this._enabled = x;
      if (this._enabled) {
        if (this.AutoReset) {
          this._intervalId = setInterval(() => {
            if (!this.AutoReset) {
              this.Enabled = false;
            }
            this._elapsed.Trigger(new Date());
          }, this.Interval) as any;
        } else {
          this._timeoutId = setTimeout(() => {
            this.Enabled = false;
            this._timeoutId = 0;
            if (this.AutoReset) {
              this.Enabled = true;
            }
            this._elapsed.Trigger(new Date());
          }, this.Interval) as any;
        }
      } else {
        if (this._timeoutId) {
          clearTimeout(this._timeoutId);
          this._timeoutId = 0;
        }
        if (this._intervalId) {
          clearInterval(this._intervalId);
          this._intervalId = 0;
        }
      }
    }
  }

  public Dispose() {
    this.Enabled = false;
    this._isDisposed = true;
  }

  public Close() {
    this.Dispose();
  }

  public Start() {
    this.Enabled = true;
  }

  public Stop() {
    this.Enabled = false;
  }
}
