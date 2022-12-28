<template>
  <div>
    <span>Login </span>
    <el-form :rules="rules" :model="user">
      <el-form-item label="Email" prop="email">
        <el-input type="text" v-model="user.email"/>
      </el-form-item>
      <el-form-item label="Password" prop="password">
        <el-input type="password" v-model="user.password"/>
      </el-form-item>
    </el-form>
    <router-link :to="{name: 'Register'}">Register</router-link>
    <router-link :to="{name: 'ForgotPassword'}">Forgot password</router-link>
  </div>
</template>

<script>
export default {
  name: "LogIn",
  data() {
    return {
      user: {
        email: "",
        password: "",
      },
      showPassword: false,
      rules: {
        email: [
          {
            required: true,
            message: "Email is required",
            trigger: ["change", "blur"],
          },
          {
            type: 'email',
            message: "Invalid email type",
            trigger: ["change", "blur"],
          }

        ],
        password: [
          {
            required: true,
            message: "Password is required",
            trigger: ["change", "blur"],
          }
        ]
      }
    }
  }
}
</script>


<style scoped>

</style>