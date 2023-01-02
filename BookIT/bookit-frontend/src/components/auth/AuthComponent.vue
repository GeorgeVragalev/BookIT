<template>
  <el-row class="auth">
    <el-col class="auth__form" :lg="8" :sm="12" :xs="24">
      <router-view/>
    </el-col>
  </el-row>
</template>

<script>
export default {
  name: "AuthComponent"
}
</script>

<style scoped lang="scss"></style>