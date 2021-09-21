import { createStore } from 'vuex'

export class DataStore {
  private store: any

  constructor () {
    this.store = createStore({
      state () {
        return {
          count: 0
        }
      },
      mutations: {
        increment (state: any) {
          state.count++
        }
      }
    })
  }

  getStore () { return this.store }
}
