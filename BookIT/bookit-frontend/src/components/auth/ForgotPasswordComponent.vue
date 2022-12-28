<template>
  <div>
    <span>Forgot Password </span>
    <router-link :to="{name: 'Register'}">Register</router-link>
    <router-link :to="{name: 'Login'}">Login</router-link>
  </div>
</template>

<script>
export default {
  name: "ForgotPasswordComponent"
}
</script>

<style scoped>

</style>