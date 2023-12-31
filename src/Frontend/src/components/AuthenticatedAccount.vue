<script setup lang="ts">
import { computed, ref } from 'vue'
import { useRouter } from 'vue-router'

import { apiHelper } from '../helpers/apiHelper'
import { tokenHelper } from '../helpers/tokenHelper'

const Router = useRouter()

const newPassword = ref<string>()

const tokenInfo = computed(() => {
  const token = tokenHelper.getToken()

  if (token === null) {
    return
  }

  return tokenHelper.parseToken(token)
})

async function logout () {
  tokenHelper.removeToken()
  await Router.push('/login')
}

async function changePassword () {
  if (!newPassword.value) {
    return
  }

  await apiHelper.changePassword(newPassword.value)
}

</script>

<template>
  <q-btn-dropdown
    icon="account_circle"
    stretch
    flat
    label="Account"
  >
    <div
      v-if="tokenInfo"
      class="text-subtitle1 q-ma-md"
    >
      <div v-if="tokenInfo.firstname || tokenInfo.lastname">
        {{ tokenInfo.firstname }} {{ tokenInfo.lastname }}
      </div>
      <div class="text-weight-medium">
        {{ tokenInfo.emailAddress }}
      </div>
      <small style="line-height:14px; display:block;">
        Token valid at<br>
        {{ tokenInfo.validAt }}
      </small>
      <q-badge
        v-for="role in tokenInfo.roles"
        :key="role"
        outline
        color="primary"
        class="q-mr-sm"
        :label="role"
      />
    </div>
    <div class="row no-wrap q-pa-md">
      <div class="column">
        <q-form>
          <q-input
            v-model="newPassword"
            label="New Password"
            autocomplete="new-password"
            type="password"
            class="q-mb-sm"
            dense
            outlined
          />
          <q-btn
            outline
            label="Change Password"
            @click="changePassword()"
          />
        </q-form>
      </div>

      <q-separator
        vertical
        inset
        class="q-mx-lg"
      />

      <div class="column items-center">
        <q-btn
          v-close-popup
          color="primary"
          label="Logout"
          outline
          @click="logout"
        />
      </div>
    </div>
  </q-btn-dropdown>
</template>
