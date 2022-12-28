<template>
  <div>
    <span>Register</span>
    <el-form :rules="rules" :model="user">
      <el-form-item label="Email" prop="email">
        <el-input type="text" v-model="user.email"/>
      </el-form-item>
      <el-form-item label="Academic group" prop="group">
        <el-select v-model="user.academicGroup">
          <el-option
              v-for="group in academicGroups"
              :key="group.id"
              :label="group.name"
              :value="group.id"
          />
        </el-select>
      </el-form-item>
      <el-form-item label="Password" prop="password">
        <el-input type="password" v-model="user.password"/>
      </el-form-item>
      <el-form-item label="Confirm password" prop="passwordConfirm">
        <el-input type="password" v-model="user.confirmPassword"/>
      </el-form-item>
    </el-form>
    <router-link :to="{name: 'Login'}">Login</router-link>
    <router-link :to="{name: 'ForgotPassword'}">Forgot password</router-link>
  </div>
</template>

<script>
export default {
  name: "RegisterComponent",
  data() {
    const confirmPasswordValidator = (rule, value, callback) => {
      if(value !== this.user.password) {
        callback(new Error("Confirm password does not match"));
      }

      callback();
    }
    return {
      user: {
        email: "",
        academicGroup: "",
        password: "",
        confirmPassword: "",
      },
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
        group: [
          {
            required: true,
            message: "Academic group is required",
            trigger: ["change", "blur"],
          }
        ],
        password: [
          {
            required: true,
            message: "Password is required",
            trigger: ["change", "blur"],
          },
          {
            min: 8,
            message: "Password is too short",
            trigger: ["change", "blur"],
          }
        ],
        passwordConfirm: [

          {
            validator: confirmPasswordValidator,
            trigger: ["change", "blur"],
          }
        ],
      }
    };
  },
  computed: {
    academicGroups() {
      return [
        {
          id: 1,
          name: "FAF-201"
        },
        {
          id: 2,
          name: "FAF-202"
        },
        {
          id: 3,
          name: "FAF-203"
        },
      ]
    },
  },
}
</script>

<style scoped>

</style>